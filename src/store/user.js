import axios from "axios";

export default {
    mutations: {
        setCreateUserCreds(state, { email, name, surname, mobile, password, roleName }) {
            state.createUserCreds.email = email;
            state.createUserCreds.name = name;
            state.createUserCreds.surname = surname;
            state.createUserCreds.mobile = mobile;
            state.createUserCreds.password = password;
            state.createUserCreds.roleName = roleName;
        },
        setUpdateUserCreds(state, { email, name, surname, mobile }) {
            state.updateUserCreds.email = email;
            state.updateUserCreds.name = name;
            state.updateUserCreds.surname = surname;
            state.updateUserCreds.mobile = mobile;
        },
    },
    state: {
        createUserCreds: {
            email: "",
            name: "",
            surname: "",
            mobile: "",
            password: "",
            roleName: "",
        },
        updateUserCreds: {
            email: "",
            name: "",
            surname: "",
            mobile: "",
        },
    },
    getters: {},
    actions: {
        async createUser(context) {
            let response;

            console.log(context.state.createUserCreds);
            try {
                await axios({
                    method: "post",
                    url: `${import.meta.env.VITE_API_URL}/api/User/create`,
                    data: {
                        email: context.state.createUserCreds.email,
                        name: context.state.createUserCreds.name,
                        surname: context.state.createUserCreds.surname,
                        mobile: context.state.createUserCreds.mobile,
                        password: context.state.createUserCreds.password,
                        roleName: context.state.createUserCreds.roleName,
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
                    url: `${import.meta.env.VITE_API_URL}/api/User/${uid}/update`,
                    data: {
                        email: context.state.updateUserCreds.email,
                        name: context.state.updateUserCreds.name,
                        surname: context.state.updateUserCreds.surname,
                        mobile: context.state.updateUserCreds.mobile,
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
                    url: `${import.meta.env.VITE_API_URL}/api/User/${uid}/delete`,
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
                    url: `${import.meta.env.VITE_API_URL}/api/User/${uid}/get`,
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
                    url: `${import.meta.env.VITE_API_URL}/api/User/getAll`,
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
