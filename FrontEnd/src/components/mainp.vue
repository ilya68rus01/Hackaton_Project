<template>
 <div>
   <div v-show="!btn" class="form-data">
    <p class="title-modal">Загрузить файл почтовых адресов:</p>
    <p>   
    <label for="upload" class="file-upload__label">Выбрать файл для загрузки {{nameFile}}</label>
    <input id="upload" accept=".csv"  class="file-upload__input" type="file" name="file-upload" ref="file" v-on:change="handleFileUpload()" required>
    </p>
    <transition name="fade2">
        <input v-show="errB" class="error-mes" type="submit" @click="close" :value="erro">
    </transition>
    <p><input type="submit" class="inline-line" v-on:click="submitFile()" value="Загрузить">
     <img :class="{'fade-element':oke}" class="img-ok inline-line" src="/assets/img/ok.svg" alt="">
    </p>
</div>
   <div v-show="btn" class="img">
     <img class="img-src" src="/assets/img/DoubleRing.gif" alt="">
   </div>
 </div>
</template>

<script>
export default {
  name:'mainp',
  data() {
    return {
        btn: false,
        file: '',
        nameFile:'',
        oke:false,
        errB:false,
        erro:'Пожалуйста, загрузите файл'
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
    submitFile(){
      if(this.file==''||this.file.type!='application/vnd.ms-excel'){
        this.errB=true;
      }else{
       let formData = new FormData();
       formData.append('file', this.file);
       this.btn=true;
       
      // this.$router.push('/finish');
       Vue.axios.post( '/AddresProcessor',
                formData,
                {
              headers: {
                  'Content-Type': 'multipart/form-data'
              }
            }
          ).then((data)=>{
          //  console.log(data.data);
            if(data.data!=false){
              this.errB=false;
            let less=setInterval(() => {
              Vue.axios.get('/AddresProcessor').then( (resp)=> {
               if(resp.data!='12'&&resp.data!=12){
               this.$router.push('/finish');
               clearInterval(less)
               }
                 })
            }, 2000);
            }else{
               this.errB=true;
               this.erro='Ошибка при загрузке'
               this.btn=false;
            }
          })
          .catch(()=>{
            this.btn=false;
            this.errB=true;
            this.erro='Ошибка при загрузке'
            this.btn=false;
          });
      }
     },
     handleFileUpload(){ 
         this.file = this.$refs.file.files[0];
         //console.log(this.file)
         if(this.file.type!='application/vnd.ms-excel'){
          this.errB=true;
          this.erro='Неверный формат файла'
        } else{
          this.errB=false;
         this.nameFile=' ('+this.file.name+')';
         this.oke=true;
         }
      },
  },
  watch:{
     // 'lng'(val){
      //}
  },
  mounted(){
    //console.log(this.$router)
  }
}
</script>

<style lang="css" local>
.error-mes{
  color:#FF0844;
  width: 100%;
  font-size: 16px;
}
.error-mes:hover{
  background-color: #6f42c1;
}
.inline-line{
  display: inline-block;
  vertical-align: top;
}

.img-ok{
  max-width: 45px;
  height: 45px;
  margin-left:25px;
  opacity: 0;
  transition: all .5s ease;
}
.fade-element{
  opacity: 1;
}
.img{
  user-select: none;
  text-align: center;
}
h1{
  font-weight: 600;
  font-size: 48px;
}
body{
  padding: 25px;
  max-width: 1023px;
  margin-right: auto;
  margin-left: auto;
  position: relative;
}
.form-data{
  padding: 10px 25px ; 
  border: 1px solid rgb(132, 87, 197);
  position: relative;
}
.title-modal{
    font-size: 32px;
    font-weight: 600;
}
input{
  background-color: #4C2B75;
  cursor: pointer;
  padding: 15px 3px;
  color: white;
  min-width: 300px;
  border: 0px solid transparent;
  outline: none;
  transition: all .5s ease;
  border-radius: .4em;
  -webkit-appearance:none;
}
input:active,input:hover{
  background-color: rgb(188, 162, 226);
}

.file-upload__label {
  display: block;
  padding: 15px 20px;
  color: #fff;
  background: #4C2B75;
  border-radius: .4em;
  transition: all .3s ease;
  cursor: pointer;
}
.file-upload__label:hover {
     background: rgb(188, 162, 226);
}  
.file-upload__input {
    position: absolute;
    left: 0;
    top: 0;
    right: 0;
    bottom: 0;
    font-size: 1;
    width:0;
    height: 100%;
    opacity: 0;
    z-index: -1;
}
.fade-enter-active {
  transition: all 1.3s ease;
}
.fade-leave-active {
  transition: all .01s ease;
}
.fade-leave-to {
  opacity: 0;
}
.fade-enter{
  opacity: 0;
}
.fade2-enter-active {
  transition: all .5s ease;
}
.fade2-leave-active {
  transition: all .5s ease;
}
.fade2-leave-to {
  opacity: 0;
}
.fade2-enter{
  opacity: 0;
}
@media (max-width: 768px){
  .error-mes{
  font-size: 14px;
}
  body {
    padding: 15px
    }
.title-modal{
    font-size: 24px;
}
h1{
  font-size: 32px;
}
.file-upload__label{
  width: 200px;
}
.error-mes{
  width: 240px;
}
input{
min-width: 240px;
}
}

@media (max-width: 395px){
.img-ok{
  display: block;
  margin-left:0px;
  margin-top:16px;
}

}
</style>
