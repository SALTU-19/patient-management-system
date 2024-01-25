<template>
    <!-- <form class="flex flex-col gap-5 justify-center w-1/2"> -->

    <div class="flex flex-col gap-5 justify-center w-1/2">
        <div class="flex justify-center">
            <h3 class="text-3xl font-medium text-black">Sign In</h3>
        </div>

        <Input v-model="signIn.email" placeholder="E-mail" type="email" class="!pr-0 text-black" outline />

        <Input v-model="signIn.password" placeholder="Password" :type="showPassword ? 'text' : 'password'"
            class="!pr-0 text-black !font-verdana !tracking-wider" outline />


        <div class="flex justify-center ">
            <button class="bg-primary text-black rounded-2xl px-4 py-2" @click="_login">Login</button>
        </div>
        <div v-if="!isUserLoggedIn" class="flex flex-col justify-center">
            <span class="flex justify-center text-sm font-semibold text-primary" style="color: red">{{ message }}</span>
        </div>
    </div>
    <!-- </form> -->
</template>
  
<script>
import Input from "@/components/forms/Input.vue"
import { mapMutations, mapActions } from "vuex";
import axios from "axios";
export default {
    components: { Input, },
    data() {
        return {
            signIn: {
                email: "",
                password: "",
            },
            isUserLoggedIn: true,
            message: "",
            showPassword: false,
        };
    },
    // when the page is loaded, clear the local storage
    created() {
        localStorage.clear();
    },

    methods: {
        ...mapMutations(["setLoginCreds"]),
        ...mapActions(["login"]),
        togglePasswordVisibility() {
            this.showPassword = !this.showPassword;
        },
        async _login() {

            this.setLoginCreds({
                email: this.signIn.email,
                password: this.signIn.password,
            });
            await this.login()
                .then((res) => {
                    console.log(res);
                    if (res.status == 200 || res.status == 201) {
                        this.isUserLoggedIn = true;
                        this.message = res.data.message[0];
                        this.userObj = res.data.data.decodedUserModel;

                        // set user in local storage
                        localStorage.setItem("user", JSON.stringify(this.userObj));
                        // set token in axios header
                        localStorage.setItem("accessToken", res.data.data.accessToken);

                        // axios.defaults.headers.common[
                        // 	"Authorization"
                        // ] = `Bearer ${res.data.data.tokens.access_token}`;
                        // this.setUser(this.userObj);
                        // set token in local storage
                        // localStorage.setItem(
                        // 	"accessToken",
                        // 	res.data.data.tokens.access_token
                        // );
                        // localStorage.setItem(
                        // 	"refreshToken",
                        // 	res.data.data.tokens.refresh_token
                        // );
                    } else {
                        this.isUserLoggedIn = false;
                        this.message = res.data.message[0];
                    }
                })
                .catch((err) => {
                    this.isUserLoggedIn = false;
                    this.message = "Something went wrong";
                });
            if (this.isUserLoggedIn) {
                this.$router.push("/");
            }
            // window.location.reload()
            // this.$router.push("/home");
        },
    },
}
</script>
  
<style scoped>
Input[type='password'] {
    font-family: Verdana !important;
    letter-spacing: 0.125em !important;
}
</style>