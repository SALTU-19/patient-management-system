import axios from "axios";

export default {
    mutations: {
        setCreateOrganizationCreds(state, { name }) {
            state.createOrganizationCreds.name = name;
        },
        setUpdateOrganizationCreds(state, { name }) {
            state.updateOrganizationCreds.name = name;
        },
    },
    state: {
        createOrganizationCreds: {
            name: "",
        },
        updateOrganizationCreds: {
            name: "",
        },
    },
    getters: {},
    actions: {
        async createOrganization(context) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/Organization/create`,
                    data: {
                        name: context.state.createOrganizationCreds.name,
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
        async updateOrganization(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/Organization/${uid}/update`,
                    data: {
                        name: context.state.createOrganizationCreds.name,
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
        async deleteOrganization(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "delete",
                    url: `https://patient-management-api.azurewebsites.net/api/Organization/${uid}/delete`,
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

        async getOrganization(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/Organization/${uid}/get`,
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
        async getAllOrganizations(context) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/Organization/getAll`,
                }).then((res) => {
                    response = res;
                });

                if (response.status == 200) {
                    console.log(response.data.message);
                    console.log(response.data);
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
