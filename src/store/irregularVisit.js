import axios from "axios";

export default {
    mutations: {
        setCreateIrregularVisitHistoryCreds(state, { date, vki, ewl, img, bloadSituation, doctorComment, patientUID }) {
            state.createIrregularVisitHistoryCreds.date = date;
            state.createIrregularVisitHistoryCreds.vki = vki;
            state.createIrregularVisitHistoryCreds.ewl = ewl;
            state.createIrregularVisitHistoryCreds.img = img;
            state.createIrregularVisitHistoryCreds.bloadSituation = bloadSituation;
            state.createIrregularVisitHistoryCreds.doctorComment = doctorComment;
            state.createIrregularVisitHistoryCreds.patientUID = patientUID;
        },
        setUpdateIrregularVisitHistoryCreds(state, { date, vki, ewl, img, bloadSituation, doctorComment }) {
            state.updateIrregularVisitHistoryCreds.date = date;
            state.updateIrregularVisitHistoryCreds.vki = vki;
            state.updateIrregularVisitHistoryCreds.ewl = ewl;
            state.updateIrregularVisitHistoryCreds.img = img;
            state.updateIrregularVisitHistoryCreds.bloadSituation = bloadSituation;
            state.updateIrregularVisitHistoryCreds.doctorComment = doctorComment;
        }
    },
    state: {
        createIrregularVisitHistoryCreds: {
            date: "",
            vki: 0,
            ewl: 0,
            img: [],
            bloadSituation: "",
            doctorComment: "",
            patientUID: "",
        },
        updateIrregularVisitHistoryCreds: {
            date: "",
            vki: 0,
            ewl: 0,
            img: [],
            bloadSituation: "",
            doctorComment: "",
        },
    },
    getters: {},
    actions: {
        async createIrregularVisitHistory(context) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/IrregularVisitHistory/create`,
                    data: {
                        date: context.state.createIrregularVisitHistoryCreds.date,
                        vki: context.state.createIrregularVisitHistoryCreds.vki,
                        ewl: context.state.createIrregularVisitHistoryCreds.ewl,
                        img: context.state.createIrregularVisitHistoryCreds.img,
                        bloadSituation: context.state.createIrregularVisitHistoryCreds.bloadSituation,
                        doctorComment: context.state.createIrregularVisitHistoryCreds.doctorComment,
                        patientUID: context.state.createIrregularVisitHistoryCreds.patientUID,
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
        async updateIrregularVisitHistory(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/IrregularVisitHistory/${uid}/update`,
                    data: {
                        date: context.state.updateIrregularVisitHistoryCreds.date,
                        vki: context.state.updateIrregularVisitHistoryCreds.vki,
                        ewl: context.state.updateIrregularVisitHistoryCreds.ewl,
                        img: context.state.updateIrregularVisitHistoryCreds.img,
                        bloadSituation: context.state.updateIrregularVisitHistoryCreds.bloadSituation,
                        doctorComment: context.state.updateIrregularVisitHistoryCreds.doctorComment,
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
        async deleteIrregularVisitHistory(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "delete",
                    url: `https://patient-management-api.azurewebsites.net/api/IrregularVisitHistory/${uid}/delete`,
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

        async getIrregularVisitHistory(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/IrregularVisitHistory/${uid}/get`,
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
        async getAllIrregularVisitHistorys(context) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/IrregularVisitHistory/getAll`,
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
