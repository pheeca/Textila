<template>     
<v-content>
  <v-card id="create">
      <v-container
        class="fill-height"
        fluid 
      > <v-layout child-flex>
       <v-data-table :headers="headers" :items="dataList" :hide-default-footer="true" class="elevation-1" > 
          <template slot="item" slot-scope="props">
            <tr>
              <td>{{ props.item.Description }}</td>
              <td class="justify-center layout px-0">
              <v-btn icon class="mx-0" :to="`/${title}/Edit/${props.item.CountId}`">
                  <v-icon color="teal">edit</v-icon>
              </v-btn>
              <v-btn icon class="mx-0" @click="deleteItem(props.item)">
                  <v-icon color="pink">delete</v-icon>
              </v-btn>
              </td>
              </tr>
          </template>
    </v-data-table>
    </v-layout>
  </v-container>   <v-card-text style="height: 100px; position: relative">
            <v-fab-transition>
              <v-btn :to="`/${title}/Create`"
                v-show="true"
                color="pink"
                dark
                absolute
                top
                right
                fab
              >
                <v-icon>mdi-plus</v-icon>
              </v-btn>
            </v-fab-transition>
          </v-card-text> </v-card>  
  </v-content>
</template>

<script>
import backendServer from './../../services/backendService';
 export default {
    data: () => ({
      title:"Count",
headers: [
    { text: 'Name', value: 'name', sortable: true },
    { text: 'Actions', value: 'Actions', sortable: false }
],
dataList: [],
 }),
mounted(){
  this.loadData();
},
    methods: {
      loadData(){
        backendServer.getCounts().then((data)=>{
          this.dataList = data;
        });
      },
      validate () {
        if (this.$refs.form.validate()) {
          this.snackbar = true
        }
      },
      reset () {
        this.$refs.form.reset()
      },
      resetValidation () {
        this.$refs.form.resetValidation()
      },
    },
  }

</script>