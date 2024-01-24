import axios from "axios";

export default {
    mutations: {
        setCreateHospitalCreds(state, { name, coordinate, address, district, city, mobile, zipCode, image }) {
            state.createHospitalCreds.name = name;
            state.createHospitalCreds.coordinate = coordinate;
            state.createHospitalCreds.address = address;
            state.createHospitalCreds.district = district;
            state.createHospitalCreds.city = city;
            state.createHospitalCreds.mobile = mobile;
            state.createHospitalCreds.zipCode = zipCode;
            state.createHospitalCreds.image = image;
        },
        setUpdateHospitalCreds(state, { name, coordinate, address, district, city, mobile, zipCode, image }) {
            state.updateHospitalCreds.name = name;
            state.updateHospitalCreds.coordinate = coordinate;
            state.updateHospitalCreds.address = address;
            state.updateHospitalCreds.district = district;
            state.updateHospitalCreds.city = city;
            state.updateHospitalCreds.mobile = mobile;
            state.updateHospitalCreds.zipCode = zipCode;
            state.updateHospitalCreds.image = image;
        },
    },
    state: {
        createHospitalCreds: {
            name: "",
            coordinate: "",
            address: "",
            district: "",
            city: "",
            mobile: "",
            zipCode: "",
            image: "",
            organizationId: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        },
        updateHospitalCreds: {
            name: "",
            coordinate: "",
            address: "",
            district: "",
            city: "",
            mobile: "",
            zipCode: "",
            image: "",
        },
    },
    getters: {},
    actions: {
        async createHospital(context) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `${import.meta.env.VITE_API_URL}/api/Hospital/create`,
                    data: {
                        name: context.state.createHospitalCreds.name,
                        coordinate: context.state.createHospitalCreds.coordinate,
                        address: context.state.createHospitalCreds.address,
                        district: context.state.createHospitalCreds.district,
                        city: context.state.createHospitalCreds.city,
                        mobile: context.state.createHospitalCreds.mobile,
                        zipCode: context.state.createHospitalCreds.zipCode,
                        image: context.state.createHospitalCreds.image,
                        organizationId: context.state.createHospitalCreds.organizationId,
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
        async updateHospital(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "post",
                    url: `${import.meta.env.VITE_API_URL}/api/Hospital/${uid}/update`,
                    data: {
                        name: context.state.updateHospitalCreds.name,
                        coordinate: context.state.updateHospitalCreds.coordinate,
                        address: context.state.updateHospitalCreds.address,
                        district: context.state.updateHospitalCreds.district,
                        city: context.state.updateHospitalCreds.city,
                        mobile: context.state.updateHospitalCreds.mobile,
                        zipCode: context.state.updateHospitalCreds.zipCode,
                        image: context.state.updateHospitalCreds.image,
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
        async deleteHospital(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "delete",
                    url: `${import.meta.env.VITE_API_URL}/api/Hospital/${uid}/delete`,
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

        async getHospital(context, { uid }) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `${import.meta.env.VITE_API_URL}/api/Hospital/${uid}/get`,
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
        async getAllHospitals(context) {
            let response;
            try {
                await axios({
                    method: "get",
                    url: `${import.meta.env.VITE_API_URL}/api/Hospital/getAll`,
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
