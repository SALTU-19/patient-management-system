import axios from "axios";

export default {
    mutations: {
        setCreateDiseaseHistoryCreds(state, { name, explonation, patientUID }) {
            state.createDiseaseHistoryCreds.name = name;
            state.createDiseaseHistoryCreds.explonation = explonation;
            state.createDiseaseHistoryCreds.patientUID = patientUID;
        },
        setUpdateDiseaseHistoryCreds(state, { name, explonation }) {
            state.updateDiseaseHistoryCreds.name = name;
            state.updateDiseaseHistoryCreds.explonation = explonation;
        },
    },
    state: {
        createDiseaseHistoryCreds: {
            name: "",
            explonation: "",
            patientUID: "",
        },
        updateDiseaseHistoryCreds: {
            name: "",
            explonation: "",
        },
    },
    getters: {},
    actions: {
        async createDiseaseHistory(context) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/DiseaseHistory/create`,
                    data: {
                        name: context.state.createDiseaseHistoryCreds.name,
                        explonation: context.state.createDiseaseHistoryCreds.explonation,
                        patientUID: context.state.createDiseaseHistoryCreds.patientUID,
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
        async updateDiseaseHistory(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/DiseaseHistory/${uid}/update`,
                    data: {
                        name: context.state.updateDiseaseHistoryCreds.name,
                        explonation: context.state.updateDiseaseHistoryCreds.explonation,
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
        async deleteDiseaseHistory(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/DiseaseHistory/${uid}/delete`,
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

        async getDiseaseHistory(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/DiseaseHistory/${uid}/get`,
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
        async getAllDiseaseHistorys(context) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/DiseaseHistory/getAll`,
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
