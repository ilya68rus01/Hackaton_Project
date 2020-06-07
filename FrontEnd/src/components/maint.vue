<template>
 <div>
<div class="form-data" v-show="!btn" >
    <p class="title-modal">Получить файл готовых почтовых адресов:</p>
    <transition name="fade2">
        <input v-show="errB" class="error-mes" type="submit" @click="close" :value="erro">
    </transition>
    <p><a :href="hr" download>
        <input name="submit" type="submit" @click="sub" value="Скачать">
        </a>
        </p>
        
</div>
   <div v-show="btn" class="img">
     <img class="img-src" src="/assets/img/DoubleRing.gif" alt="">
   </div>
 </div>
</template>

<script>
export default {
  name:'maint',
  data() {
    return {
        btn: false,
        hr:'#',
        erro:'Произошла ошибка скачивания',
        errB:false
   };
  },
  computed:{
   // lngData() {
   // return this.$store.getters.getlngData;
   // },
  },
  methods:{
    close(){
      this.errB=false;
    },
    sub(){
      this.btn=true;
      setTimeout(() => {
          this.btn=false;
          this.$router.push('/');
      }, 500);
    },
  },
  watch:{
     // 'lng'(val){
      //}
  },
  mounted(){
      Vue.axios.get('/AddresProcessor').then( (resp)=> {
       // console.log(resp)
        if(resp.data=='12'){
          this.errB=true;
        } 
        this.hr=resp.data;
      }).catch(()=>{
            this.errB=true;
      });
    //console.log(this.$router)
  
}
}

</script>

<style lang="css" local>

</style>
