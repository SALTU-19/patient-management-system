import axios from "axios";

export default {
    mutations: {
        setCreateSurgeryHistoryCreds(state, { name, date, doctorComment, patientUID }) {
            state.createSurgeryHistoryCreds.name = name;
            state.createSurgeryHistoryCreds.date = date;
            state.createSurgeryHistoryCreds.doctorComment = doctorComment;
            state.createSurgeryHistoryCreds.patientUID = patientUID;
        },
        setUpdateSurgeryHistoryCreds(state, { name, date, doctorComment }) {
            state.updateSurgeryHistoryCreds.name = name;
            state.updateSurgeryHistoryCreds.date = date;
            state.updateSurgeryHistoryCreds.doctorComment = doctorComment;
        },
    },
    state: {
        createSurgeryHistoryCreds: {
            name: "",
            date: "",
            doctorComment: "",
            patientUID: "",
        },
        updateSurgeryHistoryCreds: {
            name: "",
            date: "",
            doctorComment: "",
        },
    },
    getters: {},
    actions: {
        async createSurgeryHistory(context) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/SurgeryHistory/create`,
                    data: {
                        name: context.state.createSurgeryHistoryCreds.name,
                        date: context.state.createSurgeryHistoryCreds.date,
                        doctorComment: context.state.createSurgeryHistoryCreds.doctorComment,
                        patientUID: context.state.createSurgeryHistoryCreds.patientUID,
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
        async updateSurgeryHistory(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/SurgeryHistory/${uid}/update`,
                    data: {
                        name: context.state.updateSurgeryHistoryCreds.name,
                        date: context.state.updateSurgeryHistoryCreds.date,
                        doctorComment: context.state.updateSurgeryHistoryCreds.doctorComment,
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
        async deleteSurgeryHistory(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/SurgeryHistory/${uid}/delete`,
                }).then((res) => {
                    response = res;
                });

                return response;

            } catch (error) {
                console.log(error);
            }
        },

        async getSurgeryHistory(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/SurgeryHistory/${uid}/get`,
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
        async getAllSurgeryHistorys(context) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/SurgeryHistory/getAll`,
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
