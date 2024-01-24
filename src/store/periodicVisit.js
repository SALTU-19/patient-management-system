import axios from "axios";

export default {
    mutations: {
        setCreatePeriodicVisitHistoryCreds(state, { date, vki, ewl, img, bloadSituation, doctorComment, patientUID }) {
            state.createPeriodicVisitHistoryCreds.date = date;
            state.createPeriodicVisitHistoryCreds.vki = vki;
            state.createPeriodicVisitHistoryCreds.ewl = ewl;
            state.createPeriodicVisitHistoryCreds.img = img;
            state.createPeriodicVisitHistoryCreds.bloadSituation = bloadSituation;
            state.createPeriodicVisitHistoryCreds.doctorComment = doctorComment;
            state.createPeriodicVisitHistoryCreds.patientUID = patientUID;
        },
        setUpdatePeriodicVisitHistoryCreds(state, { date, vki, ewl, img, bloadSituation, doctorComment }) {
            state.updatePeriodicVisitHistoryCreds.date = date;
            state.updatePeriodicVisitHistoryCreds.vki = vki;
            state.updatePeriodicVisitHistoryCreds.ewl = ewl;
            state.updatePeriodicVisitHistoryCreds.img = img;
            state.updatePeriodicVisitHistoryCreds.bloadSituation = bloadSituation;
            state.updatePeriodicVisitHistoryCreds.doctorComment = doctorComment;
        }
    },
    state: {
        createPeriodicVisitHistoryCreds: {
            date: "",
            vki: 0,
            ewl: 0,
            img: [],
            bloadSituation: "",
            doctorComment: "",
            patientUID: "",
        },
        updatePeriodicVisitHistoryCreds: {
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
        async createPeriodicVisitHistory(context) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `${import.meta.env.VITE_API_URL}/api/PeriodicVisitHistory/create`,
                    data: {
                        date: context.state.createPeriodicVisitHistoryCreds.date,
                        vki: context.state.createPeriodicVisitHistoryCreds.vki,
                        ewl: context.state.createPeriodicVisitHistoryCreds.ewl,
                        img: context.state.createPeriodicVisitHistoryCreds.img,
                        bloadSituation: context.state.createPeriodicVisitHistoryCreds.bloadSituation,
                        doctorComment: context.state.createPeriodicVisitHistoryCreds.doctorComment,
                        patientUID: context.state.createPeriodicVisitHistoryCreds.patientUID,
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
        async updatePeriodicVisitHistory(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `${import.meta.env.VITE_API_URL}/api/PeriodicVisitHistory/${uid}/update`,
                    data: {
                        date: context.state.updatePeriodicVisitHistoryCreds.date,
                        vki: context.state.updatePeriodicVisitHistoryCreds.vki,
                        ewl: context.state.updatePeriodicVisitHistoryCreds.ewl,
                        img: context.state.updatePeriodicVisitHistoryCreds.img,
                        bloadSituation: context.state.updatePeriodicVisitHistoryCreds.bloadSituation,
                        doctorComment: context.state.updatePeriodicVisitHistoryCreds.doctorComment,
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
        async deletePeriodicVisitHistory(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `${import.meta.env.VITE_API_URL}/api/PeriodicVisitHistory/${uid}/delete`,
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

        async getPeriodicVisitHistory(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `${import.meta.env.VITE_API_URL}/api/PeriodicVisitHistory/${uid}/get`,
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
        async getAllPeriodicVisitHistorys(context) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `${import.meta.env.VITE_API_URL}/api/PeriodicVisitHistory/getAll`,
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
