<script>
import InputFile from "@/components/forms/InputFile.vue"
import Modal from "@/components/modals/Modal.vue"
import Input from "@/components/forms/Input.vue"
import { mapActions, mapMutations, mapGetters } from "vuex";
import Select from "@/components/forms/Select.vue"
export default {
    name: "AddHospitalModal",
    data() {
        return {
            name: "",
            city: "",
            district: "",
            mobile: "",
            address: "",
            zipCode: "",
            isSaving: false,
            isError: false,
            message: "",
            currentStep: 1,
            isSaveHovered: false,
        };
    },
    components: { InputFile, Modal, Input, Select, },
    props: ["showAddHospitalModal"],
    emits: ["close-modal"],
    computed: {

    },
    watch: {
        showAddHospitalModal(val) {
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
        ...mapActions(["createHospital"]),
        ...mapMutations(["setCreateHospitalCreds"]),

        handleForm() {
            if (this.currentStep == 2) {
                this.$emit("close-modal");
                this.$emit("is-saving", this.isSaving);
            }
        },
        resetForm() {
            this.name = "";
            this.city = "";
            this.district = "";
            this.mobile = "";
            this.isSaving = false;
            this.isError = false;
            this.message = "";
            this.currentStep = 1;
            this.isSaveHovered = false;
        },
        controlFields() {
            if (
                (this.name === "" ||
                    this.city === "" ||
                    this.district === "" ||
                    this.address === "" ||
                    this.zipCode === "" ||
                    this.mobile === "") &&
                this.showAddHospitalModal
            ) {
                this.isError = true;
                this.message = "Please fill all the fields!";
            } else if (!this.isMailValid() && this.showAddHospitalModal) {
                this.isError = true;
                this.message = "Please enter a valid email!";
            } else if (!this.isMobileValid() && this.showAddHospitalModal) {
                this.isError = true;
                this.message = "Please enter a valid mobile number!";
            } else {
                this.isError = false;
            }
        },
        isMobileValid() {
            let mobile = this.mobile;
            let mobileRegex = /^(\+90|0)?5\d{9}$/g;
            if (mobileRegex.test(mobile)) {
                return true;
            } else {
                return false;
            }
        },

        async _createHospital() {
            this.isSaving = true;
            this.setCreateHospitalCreds({
                name: this.name,
                city: this.city,
                district: this.district,
                coordinate: "0,0",
                organizationId: "00000000-0000-0000-0000-000000000000",
                mobile: this.mobile,
                address: this.address,
                zipCode: this.zipCode,
            });
            let response = await this.createHospital();

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

            isDone = await this._createHospital();

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
        <Modal title="Add Hospital" :showModal="showAddHospitalModal" @closeModal="$emit('close-modal')" noPadding
            fixedHeight :md="true">
            <template #content>
                <form class="flex-1 flex flex-col w-full h-full" @submit.prevent="handleForm">
                    <template v-if="currentStep == 1">
                        <div class="border-b flex flex-col gap-4 border-light p-6">
                            <Input v-model="name" placeholder="Name" outline :error="isError && name === ''" />
                            <Input v-model="city" placeholder="City" outline :error="isError && city === ''" />
                            <Input v-model="district" placeholder="District" outline :error="isError && district === ''" />
                            <Input v-model="mobile" placeholder="Mobile" outline
                                :error="(mobile === '' || !isMobileValid()) && isError" />
                            <Input v-model="address" placeholder="Address" outline :error="isError && address === ''" />
                            <Input v-model="zipCode" placeholder="Zip Code" outline :error="isError && zipCode === ''" />
                            <div v-if="isError" class="text-red-500 text-s text-secondary-800 text-center">
                                {{ message }}
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
                            Add Hospital
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