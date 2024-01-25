import axios from "axios";

export default {
    mutations: {
        setCreatePatientCreds(state, { name, surname, phone, mail, address, age, size, weight, bodyMassIndex, bmi, image }) {
            state.createPatientCreds.name = name;
            state.createPatientCreds.surname = surname;
            state.createPatientCreds.phone = phone;
            state.createPatientCreds.mail = mail;
            state.createPatientCreds.address = address;
            state.createPatientCreds.age = age;
            state.createPatientCreds.size = size;
            state.createPatientCreds.weight = weight;
            state.createPatientCreds.bodyMassIndex = bodyMassIndex;
            state.createPatientCreds.bmi = bmi;
            state.createPatientCreds.image = image;
        },
        setUpdatePatientCreds(state, { name, surname, phone, mail, address, age, size, weight, bodyMassIndex, bmi, image }) {
            state.updatePatientCreds.name = name;
            state.updatePatientCreds.surname = surname;
            state.updatePatientCreds.phone = phone;
            state.updatePatientCreds.mail = mail;
            state.updatePatientCreds.address = address;
            state.updatePatientCreds.age = age;
            state.updatePatientCreds.size = size;
            state.updatePatientCreds.weight = weight;
            state.updatePatientCreds.bodyMassIndex = bodyMassIndex;
            state.updatePatientCreds.bmi = bmi;
            state.updatePatientCreds.image = image;
        },
    },
    state: {
        createPatientCreds: {
            name: "",
            surname: "",
            phone: "",
            mail: "",
            address: "",
            age: 0,
            size: 0,
            weight: 0,
            bodyMassIndex: 0,
            bmi: 0,
            image: "",
        },
        updatePatientCreds: {
            name: "",
            surname: "",
            phone: "",
            mail: "",
            address: "",
            age: 0,
            size: 0,
            weight: 0,
            bodyMassIndex: 0,
            bmi: 0,
            image: "",
        },
    },
    getters: {},
    actions: {
        async createPatient(context) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/Patient/create`,
                    data: {
                        name: context.state.createPatientCreds.name,
                        surname: context.state.createPatientCreds.surname,
                        phone: context.state.createPatientCreds.phone,
                        mail: context.state.createPatientCreds.mail,
                        address: context.state.createPatientCreds.address,
                        age: context.state.createPatientCreds.age,
                        size: context.state.createPatientCreds.size,
                        weight: context.state.createPatientCreds.weight,
                        bodyMassIndex: context.state.createPatientCreds.bodyMassIndex,
                        bmi: context.state.createPatientCreds.bmi,
                        image: context.state.createPatientCreds.image,
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
        async updatePatient(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `https://patient-management-api.azurewebsites.net/api/Patient/${uid}/update`,
                    data: {
                        name: context.state.updatePatientCreds.name,
                        surname: context.state.updatePatientCreds.surname,
                        phone: context.state.updatePatientCreds.phone,
                        mail: context.state.updatePatientCreds.mail,
                        address: context.state.updatePatientCreds.address,
                        age: context.state.updatePatientCreds.age,
                        size: context.state.updatePatientCreds.size,
                        weight: context.state.updatePatientCreds.weight,
                        bodyMassIndex: context.state.updatePatientCreds.bodyMassIndex,
                        bmi: context.state.updatePatientCreds.bmi,
                        image: context.state.updatePatientCreds.image,
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
        async deletePatient(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "delete",
                    url: `https://patient-management-api.azurewebsites.net/api/Patient/${uid}/delete`,
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

        async getPatient(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/Patient/${uid}/get`,
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
        async getAllPatients(context) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `https://patient-management-api.azurewebsites.net/api/Patient/getAll`,
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
