import axios from "axios";

export default {
    mutations: {
        setCreatePreOpCreds(state, { targetWeight, doctorId, surgeryType, surgeryDate, consultedSurgeryTypes, supplimentedSurgeryTypes, assistantDoctors, patientUID }) {
            state.createPreOpCreds.targetWeight = targetWeight;
            state.createPreOpCreds.doctorId = doctorId;
            state.createPreOpCreds.surgeryType = surgeryType;
            state.createPreOpCreds.surgeryDate = surgeryDate;
            state.createPreOpCreds.consultedSurgeryTypes = consultedSurgeryTypes;
            state.createPreOpCreds.supplimentedSurgeryTypes = supplimentedSurgeryTypes;
            state.createPreOpCreds.assistantDoctors = assistantDoctors;
            state.createPreOpCreds.patientUID = patientUID;
        },
        setUpdatePreOpCreds(state, { targetWeight, doctorId, surgeryType, surgeryDate, consultedSurgeryTypes, supplimentedSurgeryTypes, assistantDoctors }) {
            state.updatePreOpCreds.targetWeight = targetWeight;
            state.updatePreOpCreds.doctorId = doctorId;
            state.updatePreOpCreds.surgeryType = surgeryType;
            state.updatePreOpCreds.surgeryDate = surgeryDate;
            state.updatePreOpCreds.consultedSurgeryTypes = consultedSurgeryTypes;
            state.updatePreOpCreds.supplimentedSurgeryTypes = supplimentedSurgeryTypes;
            state.updatePreOpCreds.assistantDoctors = assistantDoctors;
        },
    },
    state: {
        createPreOpCreds: {
            targetWeight: 0,
            doctorId: "",
            surgeryType: "",
            surgeryDate: "",
            consultedSurgeryTypes: [],
            supplimentedSurgeryTypes: [],
            assistantDoctors: [],
            patientUID: "",
        },
        updatePreOpCreds: {
            targetWeight: 0,
            doctorId: "",
            surgeryType: "",
            surgeryDate: "",
            consultedSurgerySurgeryTypes: [],
            supplimentedSurgerySurgeryTypes: [],
            assistantDoctors: [],
        },
    },
    getters: {},
    actions: {
        async createPreOp(context) {
            let response;
            console.log(context.state.createPreOpCreds);
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/PreOp/create`,
                    data: {
                        targetWeight: context.state.createPreOpCreds.targetWeight,
                        doctorId: context.state.createPreOpCreds.doctorId,
                        surgeryType: context.state.createPreOpCreds.surgeryType,
                        surgeryDate: context.state.createPreOpCreds.surgeryDate,
                        consultedSurgeryTypes: context.state.createPreOpCreds.consultedSurgeryTypes,
                        supplimentedSurgeryTypes: context.state.createPreOpCreds.supplimentedSurgeryTypes,
                        assistantDoctors: context.state.createPreOpCreds.assistantDoctors,
                        patientUID: context.state.createPreOpCreds.patientUID,
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
        async updatePreOp(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/PreOp/${uid}/update`,
                    data: {
                        targetWeight: context.state.updatePreOpCreds.targetWeight,
                        doctorId: context.state.updatePreOpCreds.doctorId,
                        surgeryType: context.state.updatePreOpCreds.surgeryType,
                        surgeryDate: context.state.updatePreOpCreds.surgeryDate,
                        consultedSurgeryTypes: context.state.updatePreOpCreds.consultedSurgeryTypes,
                        supplimentedSurgeryTypes: context.state.updatePreOpCreds.supplimentedSurgeryTypes,
                        assistantDoctors: context.state.updatePreOpCreds.assistantDoctors,
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
        async deletePreOp(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/PreOp/${uid}/delete`,
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

        async getPreOp(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/PreOp/${uid}/get`,
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
        async getAllPreOps(context) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/PreOp/getAll`,
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
