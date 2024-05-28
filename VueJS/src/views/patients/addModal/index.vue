<script>
import InputFile from "@/components/forms/InputFile.vue"
import Modal from "@/components/modals/Modal.vue"
import Input from "@/components/forms/Input.vue"
import { mapActions, mapMutations, mapGetters } from "vuex";
export default {
    name: "AddPatientModal",
    data() {
        return {
            selectedDate: null,
            selectFarm: null,
            selectJob: null,
            options: [
                {
                    id: 1,
                    name: "Option 1",
                },
                {
                    id: 2,
                    name: "Option 2",
                },
                {
                    id: 3,
                    name: "Option 3",
                },
            ],
            name: "",
            surname: "",
            email: "",
            phone: "",
            address: "",
            image: "",
            age: "",
            size: "",
            weight: "",
            bmi: "",
            isSaving: false,
            isError: false,
            message: "",

            currentStep: 1,
            isSaveHovered: false,
        };
    },
    components: { InputFile, Modal, Input },
    props: ["showAddPatientModal"],
    emits: ["close-modal"],
    computed: {


    },
    watch: {
        showAddPatientModal(val) {
            if (val) {

                this.currentStep = 1;

            } else {
                this.resetForm();
            }
        },
        isSaveHovered() {
            if (this.isSaveHovered) {
                this.controlFields();
            } else {
                this.isError = false;
            }
        },

    },
    methods: {
        ...mapActions(["createPatient"]),
        ...mapMutations(["setCreatePatientCreds"]),
        handleForm() {
            if (this.currentStep == 2) {
                this.$emit("close-modal");
                this.$emit("is-saving", this.isSaving);
            }
        },
        resetForm() {
            this.name = "";
            this.surname = "";
            this.email = "";
            this.phone = "";
            this.address = "";
            this.image = "";
            this.age = "";
            this.size = "";
            this.weight = "";
            this.bmi = "";
            this.isSaving = false;
            this.isError = false;
            this.message = "";
            this.currentStep = 1;
            this.isSaveHovered = false;
        },

        controlFields() {
            if (
                (this.name === "" ||
                    this.surname === "" ||
                    this.email === "" ||
                    this.phone === "" ||
                    this.address === "" ||
                    this.age === "" ||
                    this.size === "" ||
                    this.weight === "" ||
                    this.bmi === "") &&
                this.showAddPatientModal
            ) {
                this.isError = true;
                this.message = "Please fill all fields";
            } else if (!this.isMailValid() && this.showAddPatientModal) {
                this.isError = true;
                this.message = "Please enter a valid email!";
            } else if (!this.isMobileValid() && this.showAddPatientModal) {
                this.isError = true;
                this.message = "Please enter a valid phone number!";
            } else {
                this.isError = false;
            }
        },
        isMobileValid() {
            let phone = this.phone;
            let phoneRegex = /^(\+90|0)?5\d{9}$/g;
            if (phoneRegex.test(phone)) {
                return true;
            } else {
                return false;
            }
        },
        isMailValid() {
            let email = this.email;
            let emailRegex = /\S+@\S+\.\S+/;
            if (emailRegex.test(email)) {
                return true;
            } else {
                return false;
            }
        },

        async _createPatient() {
            this.isSaving = true;
            this.setCreatePatientCreds({
                name: this.name,
                surname: this.surname,
                phone: this.phone,
                mail: this.email,
                address: this.address,
                age: this.age,
                size: this.size,
                weight: this.weight,
                bodyMassIndex: this.bmi,
                bmi: this.bmi,
                image: this.image,
            });
            let response = await this.createPatient();
            console.log(response);
            if (response.status === 200 || response.status === 201) {
                this.isError = false;
                this.message = response.data.message;
                this.isSaving = true;
                return true;
            } else {
                console.log(response);
                this.isError = true;
                this.message = response.data.message;
                this.isSaving = false;
                return false;
            }
        },
        async finish() {
            let isDone = false;
            // let flag = await this._checkPassword();
            // if (!flag && this.password === "") {
            //     this.isSaving = false;
            //     return;
            // } else if (!flag && this.password !== "") {
            //     this.isSaving = false;
            //     this.currentStep++;
            //     return;
            // }
            // if (this.showAddDoctorModal && this.selectedUser == null) {
            //     isDone = await this._createUser();
            //     if (isDone) {
            //         await this._uploadImage(this.newUserId);
            //     }
            // } else if (this.showAddDoctorModal && this.selectedUser != null) {
            //     isDone = await this._updateUser();
            //     if (isDone) {
            //         await this._uploadImage(this.selectedUser.uId);
            //     }
            // } else if (this.showDeletePersonalModal) {
            //     await this._deleteUser();
            // }

            isDone = await this._createPatient();

            if (isDone) {
                this.currentStep++;
            }
            // this.currentStep++;
        },


    },
    async mounted() {
        // await this._getAllHospitals();
        // this.filteredHospitals = this.hospitals;
        this.resetForm();
    },
};
</script>

<template>
    <teleport to="body">
        <Modal title="Add Patient" :showModal="showAddPatientModal" @closeModal="$emit('close-modal')" noPadding fixedHeight
            :md="true">
            <template #content>
                <form class="flex-1 flex flex-col w-full h-full" @submit.prevent="handleForm">
                    <template v-if="currentStep == 1">
                        <div class="grid lg:grid-cols-2">
                            <div class="flex flex-col  items-center border-b border-r border-light ">
                                <div class="flex pt-8 pb-8 border-b w-full border-light">
                                    <InputFile type="image" class="mx-auto" @new-image="image = $event" />
                                </div>

                            </div>
                            <div class="border-b flex flex-col gap-4 border-light p-6">
                                <Input v-model="name" placeholder="Name" outline :error="isError && name === ''" />
                                <Input v-model="surname" placeholder="Surname" outline :error="isError && surname === ''" />
                                <Input placeholder="E-Mail" outline v-model="email"
                                    :error="(email === '' || !isMailValid()) && isError" />
                                <Input placeholder="Mobile" outline v-model="phone"
                                    :error="(phone === '' || !isMobileValid()) && isError" />
                                <Input v-model="address" placeholder="Address" outline :error="isError && address === ''" />
                                <Input v-model="age" placeholder="Age" outline :error="isError && age === ''" />
                                <Input v-model="size" placeholder="Size" outline :error="isError && size === ''" />
                                <Input v-model="weight" placeholder="Weight" outline :error="isError && weight === ''" />
                                <Input v-model="bmi" placeholder="BMI" outline :error="isError && bmi === ''" />
                                <div v-if="isError" class="text-red-500 text-s text-secondary-800 text-center">
                                    {{ message }}
                                </div>
                            </div>
                        </div>
                    </template>
                    <template v-if="currentStep == 2">
                        <div class="flex-1 flex flex-col justify-center items-center gap-4 w-[500px] mx-auto">
                            <div class="text-center text-2xl font-semibold text-primary">
                                {{ message }}
                            </div>
                        </div>
                    </template>
                    <div class="flex items-center gap-x-6 p-8 mt-auto border-t border-light">
                        <button v-if="currentStep != 1" class="bg-primary text-black rounded-2xl px-4 py-2 ml-auto"
                            @click="currentStep--">
                            Back
                        </button>
                        <button v-else class="bg-primary text-black rounded-2xl px-4 py-2 ml-auto"
                            @click="$emit('close-modal')">
                            Cancel
                        </button>
                        <button class="bg-primary text-black rounded-2xl px-4 py-2" v-if="currentStep != 2"
                            @mouseenter="isSaveHovered = true" @mouseleave="isSaveHovered = false" :disabled="isError"
                            v-show="currentStep == 1 || currentStep == 2" @click="finish">
                            Add Patient
                        </button>
                        <button class="bg-primary text-black rounded-2xl px-4 py-2" type="submit" v-if="currentStep == 2">
                            Done </button>
                    </div>
                </form>
            </template>
        </Modal>
    </teleport>
</template>

<style scoped>
.modal-inner {
    max-width: 550px !important;
}

input[type='password'] {
    font-family: Verdana;
    letter-spacing: 0.125em;
}
</style>