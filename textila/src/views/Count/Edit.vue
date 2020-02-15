<template>
      <v-content>
    <v-form
      ref="form"
      v-model="valid"
      lazy-validation
    > <div>
        <p>{{ SingleDouble || 'null' }}</p>
      <v-radio-group v-model="SingleDouble" :mandatory="true">
        <v-radio label="Single" value="S"></v-radio>
        <v-radio label="Double" value="D"></v-radio>
      </v-radio-group>
    </div>
      <v-text-field
        v-model="name"
        :counter="10"
        :rules="nameRules"
        label="Name"
        required
      ></v-text-field>
         <v-autocomplete
        v-model="blend"
        :items="items"
        :loading="false"
       :rules="[v => !!v || 'This is required']"
       required
        color="white"
        hide-no-data
        hide-selected
        item-text="BlendName"
        item-value="BlendId"
        label="Blend"
        placeholder="Start typing to Search Blend"
        return-object
        :search-input.sync="search"
      ></v-autocomplete>{{search}}
      <v-text-field
        v-model="Description"
        readonly="readonly"
        label="Description"
        required
      ></v-text-field>
      
  
      <v-btn
        :disabled="!valid"
        color="success"
        class="mr-4"
        @click="create"
      >
        Create
      </v-btn> <v-snackbar
      v-model="snackbar"
    >
      {{ text }}
      <v-btn
        color="pink"
        text
        @click="snackbar = false"
      >
        Close
      </v-btn>
    </v-snackbar>
    </v-form>
      </v-content>
</template>
<script>

import backendServer from './../../services/backendService';
 export default {
    data: () => ({
      old_Description:null,
      search:'',
      valid: true,
      name: '',
      text: 'Updated!',
      SingleDouble: 'S',
      nameRules: [
        v => !!v || 'Name is required',
        v => (v && v.length <= 10) || 'Name must be less than 10 characters',
      ],
      blend: null,
      items: [],
      snackbar:false,
    }),
  computed: {
    Description: function () {
        return this.name.toUpperCase()+'/'+this.SingleDouble+' '+((this.blend||{}).BlendName||'')
    }
  },
  mounted(){
    backendServer.getCount(this.$route.params.id).then(a=>{
      this.name=a.CountName;
      this.SingleDouble=a.SingleDouble;
      this.blend={ BlendId:a.Blend, BlendName:a.BlendName};
      this.old_Description=a.Description;
      this.search = a.BlendName;
    })
},
watch: {
      search (val) {
        // Items have already been loaded
        val = val ? val : '';
        if (val.length == 0){
          this.items=[];
          return
        }

        // Items have already been requested
        if (this.isLoading) return

        this.isLoading = true
        backendServer.searchBlends(val)
          .then(res => {
            this.items = res;
          })
          .finally(() => (this.isLoading = false))
      },
    },
    methods: {
      create () {
        if (this.$refs.form.validate()) {
          backendServer.updateCount(this.$route.params.id,{
  "CountName": this.name,
  "SingleDouble": this.SingleDouble,
  "Blend": this.blend.BlendId,
  "Description": this.Description
}).then(() => {
             this.snackbar = true
          })
         
        }
      },
    },
  }
</script>