import{_ as l,o as s,c as n,F as o,j as d,d as a,t as m,n as u}from"./index-pE5mnqQf.js";const p={name:"TabBar",data(){return{selectedMenuItem:1}},props:{menuList:{type:Array,default:()=>[]}},methods:{handleMenuItemClick(t){this.selectedMenuItem=t,this.$emit("selected-menu-item",t)}},mounted(){this.selectedMenuItem=1},emits:["selected-menu-item"]},_={class:"px-5 flex flex-row items-center justify-between gap-52"},f=["onClick"],h={class:"text-black font-bold mr-3 cursor-pointer"};function x(t,k,r,b,c,i){return s(),n("nav",_,[(s(!0),n(o,null,d(r.menuList,e=>(s(),n("div",{key:e.id,onClick:M=>i.handleMenuItemClick(e.id)},[a("div",{class:u([{"rounded-full bg-[#FFE600] p-3 pr-1":c.selectedMenuItem===e.id},"flex flex-row items-center"])},[a("span",h,m(e.name),1)],2)],8,f))),128))])}const B=l(p,[["render",x]]);export{B as t};