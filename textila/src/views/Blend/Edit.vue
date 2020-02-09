<template>
      <v-content>
    <v-form
      ref="form"
      v-model="valid"
      lazy-validation
    > 
      <v-text-field
        v-model="name"
        :counter="10"
        :rules="nameRules"
        label="Name"
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
      search:'',
      valid: true,
      name: '',
      text: 'Created!',
      nameRules: [
        v => !!v || 'Name is required',
        v => (v && v.length <= 10) || 'Name must be less than 10 characters',
      ],
      snackbar:false,
    }),
  computed: {
  },
watch: {
     
    },
    mounted:function(){
      backendServer.getBlend(this.$route.params.id)
      .then((data)=>{
          this.name=data.BlendName;
      })
    },
    methods: {
      
      create () {
        if (this.$refs.form.validate()) {
          backendServer.updateBlend(this.$route.params.id,{ BlendName: this.name}).then(()=>{

          this.snackbar = true
          });
        }
      },
    },
  }
</script>