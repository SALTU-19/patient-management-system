import axios from "axios";

export default {
    mutations: {
        setCreateUserCreds(state, { email, name, surname, mobile, password, roleName, userImage }) {
            state.createUserCreds.email = email;
            state.createUserCreds.name = name;
            state.createUserCreds.surname = surname;
            state.createUserCreds.mobile = mobile;
            state.createUserCreds.password = password;
            state.createUserCreds.roleName = roleName;
            state.createUserCreds.userImage = userImage;
        },
        setUpdateUserCreds(state, { email, name, surname, mobile, roleName, userImage }) {
            state.updateUserCreds.email = email;
            state.updateUserCreds.name = name;
            state.updateUserCreds.surname = surname;
            state.updateUserCreds.mobile = mobile;
            state.updateUserCreds.roleName = roleName;
            state.updateUserCreds.userImage = userImage;
        },
        setLoginCreds(state, { email, password }) {
            state.loginCreds.email = email;
            state.loginCreds.password = password;
        },
    },
    state: {
        loginCreds: {
            email: "",
            password: "",
        },
        createUserCreds: {
            email: "",
            name: "",
            surname: "",
            mobile: "",
            password: "",
            roleName: "",
            userImage: null,
        },
        updateUserCreds: {
            email: "",
            name: "",
            surname: "",
            mobile: "",
            roleName: null,
            userImage: null,
        },
    },
    getters: {},
    actions: {
        async login(context) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/Auth/signin`,
                    data: {
                        email: context.state.loginCreds.email,
                        password: context.state.loginCreds.password,
                    },
                }).then((res) => {
                    response = res;
                });

                return response;

                // if (response.status == 200) {
                //     console.log(response.data.message);
                //     return response.data.data;
                // }
                // else {
                //     console.log(response.message);
                //     return null;
                // }
            } catch (error) {
                console.log(error);
            }
        },
        async createUser(context) {
            let response;

            console.log(context.state.createUserCreds);
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/User/create`,
                    data: {
                        email: context.state.createUserCreds.email,
                        name: context.state.createUserCreds.name,
                        surname: context.state.createUserCreds.surname,
                        mobile: context.state.createUserCreds.mobile,
                        password: context.state.createUserCreds.password,
                        roleName: context.state.createUserCreds.roleName,
                        userImage: context.state.createUserCreds.userImage,
                    },
                }).then((res) => {
                    response = res;
                });

                return response;

                // if (response.status == 200) {
                //     console.log(response.data.message);
                //     return response.data.data;
                // }
                // else {
                //     console.log(response.message);
                //     return null;
                // }
            } catch (error) {
                console.log(error);
            }
        },
        async updateUser(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/User/${uid}/update`,
                    data: {
                        email: context.state.updateUserCreds.email,
                        name: context.state.updateUserCreds.name,
                        surname: context.state.updateUserCreds.surname,
                        mobile: context.state.updateUserCreds.mobile,
                        roleName: context.state.updateUserCreds.roleName,
                        userImage: context.state.updateUserCreds.userImage,
                    },
                }).then((res) => {
                    response = res;
                });

                if (response.status == 200) {
                    console.log(response.data.message);
                    return response.data.data;
                }
                else {
                    console.log(response.message);
                    return null;
                }
            } catch (error) {
                console.log(error);
            }
        },
        async deleteUser(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "delete",
                    url: `https://patient-management-api.azurewebsites.net/api/User/${uid}/delete`,
                }).then((res) => {
                    response = res;
                });

                if (response.status == 200) {
                    console.log(response.data.message);
                    return response.data.data;
                }
                else {
                    console.log(response.message);
                    return null;
                }
            } catch (error) {
                console.log(error);
            }
        },

        async getUser(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/User/${uid}/get`,
                }).then((res) => {
                    response = res;
                });

                if (response.status == 200) {
                    console.log(response.data.message);
                    return response.data.data;
                }
                else {
                    console.log(response.message);
                    return null;
                }
            } catch (error) {
                console.log(error);
            }
        },
        async getAllUsers(context) {

            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/User/getAll`,
                }).then((res) => {
                    response = res;
                });

                if (response.status == 200) {
                    console.log(response.data.message);

                    return response.data.data;
                }
                else {
                    console.log(response.message);
                    return null;
                }
            } catch (error) {
                console.log(error);
            }
        },
    },



};
