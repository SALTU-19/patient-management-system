import{D as C,a as H,b as M,c as A,S as _}from"./SearchBar-5eEUiUXa.js";import{C as k,A as V}from"./AtomSpinner-Sdoxd1dX.js";import{I as D,M as E}from"./Modal-faAevnTz.js";import{I as L}from"./Input-w4Lr5OBu.js";import{a as x,m as F,_ as b,r as n,o as r,g as I,b as o,w as c,d as p,c as l,t as g,e as m,h as P,v as B,i as T,T as z,F as U}from"./index-pE5mnqQf.js";import{S as G}from"./Select-C2huDAPV.js";import"./IconSearch-5qFAVXBc.js";const K={name:"AddHospitalModal",data(){return{name:"",city:"",district:"",mobile:"",address:"",zipCode:"",isSaving:!1,isError:!1,message:"",currentStep:1,isSaveHovered:!1}},components:{InputFile:D,Modal:E,Input:L,Select:G},props:["showAddHospitalModal"],emits:["close-modal"],computed:{},watch:{showAddHospitalModal(i){i?this.currentStep=1:this.resetForm()},isSaveHovered(){this.isSaveHovered?this.controlFields():this.isError=!1}},methods:{...x(["createHospital"]),...F(["setCreateHospitalCreds"]),handleForm(){this.currentStep==2&&(this.$emit("close-modal"),this.$emit("is-saving",this.isSaving))},resetForm(){this.name="",this.city="",this.district="",this.mobile="",this.isSaving=!1,this.isError=!1,this.message="",this.currentStep=1,this.isSaveHovered=!1},controlFields(){(this.name===""||this.city===""||this.district===""||this.address===""||this.zipCode===""||this.mobile==="")&&this.showAddHospitalModal?(this.isError=!0,this.message="Please fill all the fields!"):!this.isMailValid()&&this.showAddHospitalModal?(this.isError=!0,this.message="Please enter a valid email!"):!this.isMobileValid()&&this.showAddHospitalModal?(this.isError=!0,this.message="Please enter a valid mobile number!"):this.isError=!1},isMobileValid(){let i=this.mobile;return!!/^(\+90|0)?5\d{9}$/g.test(i)},async _createHospital(){this.isSaving=!0,this.setCreateHospitalCreds({name:this.name,city:this.city,district:this.district,coordinate:"0,0",organizationId:"00000000-0000-0000-0000-000000000000",mobile:this.mobile,address:this.address,zipCode:this.zipCode});let i=await this.createHospital();return i.status===200||i.status===201?(this.isError=!1,this.message=i.data.message,this.isSaving=!0,!0):(console.log(i),this.isError=!0,this.message=i.data.message,this.isSaving=!1,!1)},async finish(){let i=!1;i=await this._createHospital(),i&&this.currentStep++}},async mounted(){this.resetForm()}},N={key:0,class:"border-b flex flex-col gap-4 border-light p-6"},j={key:0,class:"text-red-500 text-s text-secondary-800 text-center"},R={key:1,class:"flex-1 flex flex-col justify-center items-center gap-4 w-[500px] mx-auto"},Z={class:"text-center text-2xl font-semibold text-primary"},q={class:"flex items-center gap-x-6 p-8 mt-auto border-t border-light"},J=["disabled"],O={key:3,class:"bg-primary text-black rounded-2xl px-4 py-2",type:"submit"};function Q(i,s,f,y,e,d){const a=n("Input"),h=n("Modal");return r(),I(z,{to:"body"},[o(h,{title:"Add Hospital",showModal:f.showAddHospitalModal,onCloseModal:s[12]||(s[12]=t=>i.$emit("close-modal")),noPadding:"",fixedHeight:"",md:!0},{content:c(()=>[p("form",{class:"flex-1 flex flex-col w-full h-full",onSubmit:s[11]||(s[11]=T((...t)=>d.handleForm&&d.handleForm(...t),["prevent"]))},[e.currentStep==1?(r(),l("div",N,[o(a,{modelValue:e.name,"onUpdate:modelValue":s[0]||(s[0]=t=>e.name=t),placeholder:"Name",outline:"",error:e.isError&&e.name===""},null,8,["modelValue","error"]),o(a,{modelValue:e.city,"onUpdate:modelValue":s[1]||(s[1]=t=>e.city=t),placeholder:"City",outline:"",error:e.isError&&e.city===""},null,8,["modelValue","error"]),o(a,{modelValue:e.district,"onUpdate:modelValue":s[2]||(s[2]=t=>e.district=t),placeholder:"District",outline:"",error:e.isError&&e.district===""},null,8,["modelValue","error"]),o(a,{modelValue:e.mobile,"onUpdate:modelValue":s[3]||(s[3]=t=>e.mobile=t),placeholder:"Mobile",outline:"",error:(e.mobile===""||!d.isMobileValid())&&e.isError},null,8,["modelValue","error"]),o(a,{modelValue:e.address,"onUpdate:modelValue":s[4]||(s[4]=t=>e.address=t),placeholder:"Address",outline:"",error:e.isError&&e.address===""},null,8,["modelValue","error"]),o(a,{modelValue:e.zipCode,"onUpdate:modelValue":s[5]||(s[5]=t=>e.zipCode=t),placeholder:"Zip Code",outline:"",error:e.isError&&e.zipCode===""},null,8,["modelValue","error"]),e.isError?(r(),l("div",j,g(e.message),1)):m("",!0)])):m("",!0),e.currentStep==2?(r(),l("div",R,[p("div",Z,g(e.message),1)])):m("",!0),p("div",q,[e.currentStep!=1?(r(),l("button",{key:0,class:"bg-primary text-black rounded-2xl px-4 py-2 ml-auto",onClick:s[6]||(s[6]=t=>e.currentStep--)}," Back ")):(r(),l("button",{key:1,class:"bg-primary text-black rounded-2xl px-4 py-2 ml-auto",onClick:s[7]||(s[7]=t=>i.$emit("close-modal"))}," Cancel ")),e.currentStep!=2?P((r(),l("button",{key:2,class:"bg-primary text-black rounded-2xl px-4 py-2",onMouseenter:s[8]||(s[8]=t=>e.isSaveHovered=!0),onMouseleave:s[9]||(s[9]=t=>e.isSaveHovered=!1),disabled:e.isError,onClick:s[10]||(s[10]=(...t)=>d.finish&&d.finish(...t))}," Add Hospital ",40,J)),[[B,e.currentStep==1||e.currentStep==2]]):m("",!0),e.currentStep==2?(r(),l("button",O," Done ")):m("",!0)])],32)]),_:1},8,["showModal"])])}const W=b(K,[["render",Q],["__scopeId","data-v-707fd235"]]),X={name:"hospital",components:{DxDataGrid:C,DxColumn:H,DxPaging:M,DxPager:A,ContentPanel:k,SearchBar:_,AddHospitalModal:W,AtomSpinner:V},props:{},data(){return{searchTerm:"",showAddHospitalModal:!1,hospitals:[{id:1,name:"Ali",city:"İstanbul",district:"Kadıköy",mobile:"05555555555"},{id:2,name:"David",city:"İstanbul",district:"Kadıköy",mobile:"05555555555"},{id:3,name:"Cristiano",city:"İstanbul",district:"Kadıköy",mobile:"05555555555"},{id:4,name:"Lionel",city:"İstanbul",district:"Kadıköy",mobile:"05555555555"}],isSaving:!1,filteredHospitals:[],isLoading:!0}},computed:{filteredItems(){return this.hospitals.filter(i=>i.name.toLowerCase().includes(this.searchTerm.toLowerCase())||i.city.toLowerCase().includes(this.searchTerm.toLowerCase())||i.mobile.toLowerCase().includes(this.searchTerm.toLowerCase())||i.district.toLowerCase().includes(this.searchTerm.toLowerCase()))}},methods:{...x(["getAllHospitals"]),async _getAllHospitals(){this.isLoading=!0;try{this.hospitals=await this.getAllHospitals(),this.isLoading=!1}catch(i){console.log(i)}}},watch:{async isSaving(i){this.isSaving&&await this._getAllHospitals()}},async mounted(){await this._getAllHospitals()}},Y={class:"w-[1090px] flex flex-row items-center justify-between"},$={class:"w-[150px]"},ee={key:0,class:"flex justify-center items-center h-[500px]"},se={key:1,class:"table-responsive"};function te(i,s,f,y,e,d){const a=n("SearchBar"),h=n("AtomSpinner"),t=n("DxColumn"),v=n("DxDataGrid"),S=n("ContentPanel"),w=n("AddHospitalModal");return r(),l(U,null,[o(S,null,{header:c(()=>[p("div",Y,[o(a,{items:e.hospitals,placeholder:"Search Hospital","onUpdate:searchTerm":s[0]||(s[0]=u=>e.searchTerm=u),class:"w-full"},null,8,["items"]),p("div",$,[p("button",{class:"bg-primary text-black text-sm rounded-2xl px-4 py-2",onClick:s[1]||(s[1]=u=>e.showAddHospitalModal=!0)},"+ Add Hospital")])])]),content:c(()=>[e.isLoading?(r(),l("div",ee,[o(h,{color:"#BEEBE5","animation-duration":1e3})])):m("",!0),e.isLoading?m("",!0):(r(),l("div",se,[o(v,{"data-source":d.filteredItems,class:"clickable-row",selection:{mode:"single"}},{default:c(()=>[o(t,{"data-field":"name",alignment:"center"}),o(t,{"data-field":"city",alignment:"center"}),o(t,{"data-field":"mobile",alignment:"center"}),o(t,{"data-field":"district",alignment:"center"})]),_:1},8,["data-source"])]))]),_:1}),o(w,{showAddHospitalModal:e.showAddHospitalModal,onCloseModal:s[2]||(s[2]=u=>e.showAddHospitalModal=!1),onIsSaving:s[3]||(s[3]=u=>e.isSaving=u)},null,8,["showAddHospitalModal"])],64)}const me=b(X,[["render",te]]);export{me as default};
