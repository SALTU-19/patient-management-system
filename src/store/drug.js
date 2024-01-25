import axios from "axios";

export default {
    mutations: {
        setCreateDrugHistoryCreds(state, { name, startingDate, endingDate, doctorComment, patientUID }) {
            state.createDrugHistoryCreds.name = name;
            state.createDrugHistoryCreds.startingDate = startingDate;
            state.createDrugHistoryCreds.endingDate = endingDate;
            state.createDrugHistoryCreds.doctorComment = doctorComment;
            state.createDrugHistoryCreds.patientUID = patientUID;
        },
        setUpdateDrugHistoryCreds(state, { name, startingDate, endingDate, doctorComment }) {
            state.updateDrugHistoryCreds.name = name;
            state.updateDrugHistoryCreds.startingDate = startingDate;
            state.updateDrugHistoryCreds.endingDate = endingDate;
            state.updateDrugHistoryCreds.doctorComment = doctorComment;
        },
    },
    state: {
        createDrugHistoryCreds: {
            name: "",
            startingDate: "",
            endingDate: "",
            doctorComment: "",
            patientUID: "",
        },
        updateDrugHistoryCreds: {
            name: "",
            startingDate: "",
            endingDate: "",
            doctorComment: "",
        },
    },
    getters: {},
    actions: {
        async createDrugHistory(context) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/DrugHistory/create`,
                    data: {
                        name: context.state.createDrugHistoryCreds.name,
                        startingDate: context.state.createDrugHistoryCreds.startingDate,
                        endingDate: context.state.createDrugHistoryCreds.endingDate,
                        doctorComment: context.state.createDrugHistoryCreds.doctorComment,
                        patientUID: context.state.createDrugHistoryCreds.patientUID,

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
        async updateDrugHistory(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/DrugHistory/${uid}/update`,
                    data: {
                        name: context.state.updateDrugHistoryCreds.name,
                        startingDate: context.state.updateDrugHistoryCreds.startingDate,
                        endingDate: context.state.updateDrugHistoryCreds.endingDate,
                        doctorComment: context.state.updateDrugHistoryCreds.doctorComment,
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
        async deleteDrugHistory(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/DrugHistory/${uid}/delete`,
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

        async getDrugHistory(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/DrugHistory/${uid}/get`,
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
        async getAllDrugHistorys(context) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/DrugHistory/getAll`,
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
