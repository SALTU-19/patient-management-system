import axios from "axios";

export default {
    mutations: {
        setCreatePostOpCreds(state, { doctorId, doctorComment, surgeryType, drenaj, surgeryDate, consultedMedications, supplimentedMedications, patientUID }) {
            state.createPostOpCreds.doctorId = doctorId;
            state.createPostOpCreds.doctorComment = doctorComment;
            state.createPostOpCreds.surgeryType = surgeryType;
            state.createPostOpCreds.drenaj = drenaj;
            state.createPostOpCreds.surgeryDate = surgeryDate;
            state.createPostOpCreds.consultedMedications = consultedMedications;
            state.createPostOpCreds.supplimentedMedications = supplimentedMedications;
            state.createPostOpCreds.patientUID = patientUID;
        },
        setUpdatePostOpCreds(state, { doctorId, doctorComment, surgeryType, drenaj, surgeryDate, consultedMedications, supplimentedMedications }) {
            state.updatePostOpCreds.doctorId = doctorId;
            state.updatePostOpCreds.doctorComment = doctorComment;
            state.updatePostOpCreds.surgeryType = surgeryType;
            state.updatePostOpCreds.drenaj = drenaj;
            state.updatePostOpCreds.surgeryDate = surgeryDate;
            state.updatePostOpCreds.consultedMedications = consultedMedications;
            state.updatePostOpCreds.supplimentedMedications = supplimentedMedications;
        }
    },
    state: {
        createPostOpCreds: {
            doctorId: "",
            doctorComment: "",
            surgeryType: "",
            drenaj: "",
            surgeryDate: "",
            consultedMedications: [],
            supplimentedMedications: [],
            patientUID: "",
        },
        updatePostOpCreds: {
            doctorId: "",
            surgeryType: "",
            surgeryDate: "",
            consultedMedications: [],
            supplimentedMedications: [],
        },
    },
    getters: {},
    actions: {
        async createPostOp(context) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `${import.meta.env.VITE_API_URL}/api/PostOp/create`,
                    data: {
                        doctorId: context.state.createPostOpCreds.doctorId,
                        doctorComment: context.state.createPostOpCreds.doctorComment,
                        surgeryType: context.state.createPostOpCreds.surgeryType,
                        drenaj: context.state.createPostOpCreds.drenaj,
                        surgeryDate: context.state.createPostOpCreds.surgeryDate,
                        consultedMedications: context.state.createPostOpCreds.consultedMedications,
                        supplimentedMedications: context.state.createPostOpCreds.supplimentedMedications,
                        patientUID: context.state.createPostOpCreds.patientUID,
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
        async updatePostOp(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `${import.meta.env.VITE_API_URL}/api/PostOp/${uid}/update`,
                    data: {
                        doctorId: context.state.updatePostOpCreds.doctorId,
                        doctorComment: context.state.updatePostOpCreds.doctorComment,
                        surgeryType: context.state.updatePostOpCreds.surgeryType,
                        drenaj: context.state.updatePostOpCreds.drenaj,
                        surgeryDate: context.state.updatePostOpCreds.surgeryDate,
                        consultedMedications: context.state.updatePostOpCreds.consultedMedications,
                        supplimentedMedications: context.state.updatePostOpCreds.supplimentedMedications,
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
        async deletePostOp(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `${import.meta.env.VITE_API_URL}/api/PostOp/${uid}/delete`,
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

        async getPostOp(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `${import.meta.env.VITE_API_URL}/api/PostOp/${uid}/get`,
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
        async getAllPostOps(context) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `${import.meta.env.VITE_API_URL}/api/PostOp/getAll`,
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
