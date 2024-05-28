<script>
import InputFile from "@/components/forms/InputFile.vue"
import Modal from "@/components/modals/Modal.vue"
import CreateTagList from "@/components/forms/CreateTagList.vue"
import Select from "@/components/forms/Select.vue"
import Input from "@/components/forms/Input.vue"
import { mapActions, mapMutations, mapGetters } from "vuex";
export default {
    name: "AddPreOpModal",
    data() {
        return {
            targetWeight: "",
            selectedDoctorName: "",
            surgeryType: "",
            surgeryDate: "",
            surgeryTypes: [
                {
                    id: 1,
                    name: "Knee Replacement",
                },
                {
                    id: 2,
                    name: "Hip Replacement",
                }
            ],
            consultedSurgeryTypes: [],
            supplimentedSurgeryTypes: [],
            assistantDoctors: [],
            doctors: [],
            hospital: "",
            currentStep: 1,
            isSaveHovered: false,
            isSaving: false,
            isError: false,
            message: "",

        };
    },
    components: {
        InputFile,
        Modal,
        CreateTagList,
        Input,
        Select,
    },
    props: ["showAddPreOpModal", "patientUID"],
    emits: ["close-modal"],
    watch: {
        showAddPreOpModal(val) {
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
        ...mapActions(["createPreOp", "getAllUsers"]),
        ...mapMutations(["setCreatePreOpCreds"]),

        handleForm() {
            if (this.currentStep == 2) {
                this.$emit("close-modal");
                this.$emit("is-saving", this.isSaving);
            }
        },
        resetForm() {
            this.targetWeight = "";
            this.selectedDoctorName = "";
            this.surgeryType = "";
            this.surgeryDate = "";
            this.consultedSurgeryTypes = [];
            this.supplimentedSurgeryTypes = [];
            this.assistantDoctors = [];
            this.hospital = "";

            this.isSaving = false;
            this.isError = false;
            this.message = "";
            this.currentStep = 1;
            this.isSaveHovered = false;
        },
        controlFields() {

            if (
                (this.targetWeight === "" ||
                    this.selectedDoctorName === "" ||
                    this.surgeryType === "" ||
                    this.surgeryDate === "" ||
                    // this.hospital === "" ||
                    this.consultedSurgeryTypes.length === 0 ||
                    this.supplimentedSurgeryTypes.length === 0 ||
                    this.assistantDoctors.length === 0
                ) &&
                this.showAddPreOpModal
            ) {


                this.isError = true;
                this.message = "Please fill all the fields!";
            } else {
                this.isError = false;
            }
        },

        async _getAllUsers() {
            try {
                this.doctors = await this.getAllUsers();
                console.log(this.doctors);
            } catch (error) {
                console.log(error);
            }
        },
        async _createPreOp() {
            this.isSaving = true;
            let doctorId = this.doctors.find(x => x.name === this.selectedDoctorName).uId;
            let _supplimentedSurgeryTypes = [];
            let _consultedSurgeryTypes = [];
            let _assistantDoctors = [];

            // just add the name of the doctor

            for (let i = 0; i < this.supplimentedSurgeryTypes.length; i++) {
                _supplimentedSurgeryTypes.push(this.supplimentedSurgeryTypes[i].name);
            }

            for (let i = 0; i < this.consultedSurgeryTypes.length; i++) {
                _consultedSurgeryTypes.push(this.consultedSurgeryTypes[i].name);
            }

            for (let i = 0; i < this.assistantDoctors.length; i++) {
                _assistantDoctors.push(this.assistantDoctors[i].name);
            }



            this.setCreatePreOpCreds({
                targetWeight: parseInt(this.targetWeight),
                doctorId: doctorId,
                surgeryType: this.surgeryType,
                surgeryDate: this.surgeryDate + "T" + new Date(this.surgeryDate).toISOString().split('T')[1],
                consultedSurgeryTypes: _consultedSurgeryTypes,
                supplimentedSurgeryTypes: _supplimentedSurgeryTypes,
                assistantDoctors: _assistantDoctors,
                // hospital: this.hospital,
                patientUID: this.patientUID,
            });
            let response = await this.createPreOp();

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

            isDone = await this._createPreOp();

            if (isDone) {
                this.currentStep++;
            }
            // this.currentStep++;
        },
    },
    async mounted() {
        // await this._getAllDiseaseHistorys();
        // this.filteredDiseaseHistorys = this.hospitals;
        await this._getAllUsers();
        this.resetForm();
    },
};
</script>

<template>
    <teleport to="body">
        <Modal title="Add PreOp" :showModal="showAddPreOpModal" @closeModal="$emit('close-modal')" noPadding fixedHeight
            :md="true">
            <template #content>
                <form class="flex-1 flex flex-col w-full h-full" @submit.prevent="handleForm">
                    <template v-if="currentStep == 1">
                        <div class="border-b flex flex-col gap-4 border-light p-6">
                            <Input v-model="targetWeight" placeholder="Target Weight" outline
                                :error="isError && targetWeight === ''" />
                            <Select outline v-model="selectedDoctorName" placeholder="Select Doctor" :options="doctors"
                                :error="isError && selectedDoctorName === ''" />
                            <Select outline v-model="surgeryType" placeholder="Select Surgery Type" :options="surgeryTypes"
                                :error="isError && surgeryType === ''" />
                            <CreateTagList v-model="supplimentedSurgeryTypes" placeholder="Supplimented Surgery Type"
                                scrollHeight="410px" :options="surgeryTypes"
                                :error="isError && supplimentedSurgeryTypes.length === 0" />
                            <CreateTagList v-model="consultedSurgeryTypes" placeholder="Consulted Surgery Type"
                                scrollHeight="410px" :options="surgeryTypes"
                                :error="isError && consultedSurgeryTypes.length === 0" />
                            <div class="flex flex-row gap-4">
                                <div class="flex flex-col gap-4">
                                    <div class="text-black text-sm font-semibold">Surgery Date</div>
                                    <Input v-model="surgeryDate" type="date" placeholder="Surgery Date" outline
                                        :error="isError && surgeryDate === ''" />
                                </div>
                                <!-- <div class="flex flex-col gap-4">
                                    <div class="text-black text-sm font-semibold">Hospital</div>
                                    <Input v-mode="hospital" placeholder="Hospital" outline
                                        :error="isError && hospital === ''" />
                                </div> -->
                            </div>
                            <CreateTagList v-model="assistantDoctors" placeholder="Asistant Doctors" scrollHeight="410px"
                                :options="doctors" :error="isError && assistantDoctors.length === 0" />
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
                            Add Pre Op
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