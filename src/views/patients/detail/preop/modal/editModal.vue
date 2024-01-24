<script>
import InputFile from "@/components/forms/InputFile.vue"
import Modal from "@/components/modals/Modal.vue"
import CreateTagList from "@/components/forms/CreateTagList.vue"
import Select from "@/components/forms/Select.vue"
import Input from "@/components/forms/Input.vue"
import { mapActions, mapMutations, mapGetters } from "vuex";
export default {
    name: "EditPreOpModal",
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
    props: ["showEditPreOpModal", "selectedPreOp"],
    emits: ["close-modal"],
    watch: {
        showEditPreOpModal(val) {
            if (val) {
                this.currentStep = 1;
                this.resetForm();

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
        ...mapActions(["updatePreOp", "getAllUsers"]),
        ...mapMutations(["setUpdatePreOpCreds"]),

        handleForm() {
            if (this.currentStep == 2) {
                this.$emit("close-modal");
                this.$emit("is-saving", this.isSaving);
            }
        },
        convertDateFormat(inputDate) {
            // Split the input date into day, month, and year
            const dateParts = inputDate.split('.');

            // Create a new Date object using the parsed values
            const newDate = new Date(`${dateParts[2]}-${dateParts[1]}-${dateParts[0]}`);

            // Extract the year, month, and day from the new Date object
            const year = newDate.getFullYear();
            const month = (newDate.getMonth() + 1).toString().padStart(2, '0'); // Months are zero-indexed, so we add 1
            const day = newDate.getDate().toString().padStart(2, '0');

            // Construct the new date format
            const newDateFormat = `${year}-${month}-${day}`;

            return newDateFormat;
        },
        resetForm() {
            if (this.selectedPreOp != null) {
                this.targetWeight = this.selectedPreOp.targetWeight;
                this.selectedDoctorName = this.selectedPreOp.doctorName.split(' ')[0];
                this.surgeryType = this.selectedPreOp.surgeryType;
                this.surgeryDate = this.convertDateFormat(this.selectedPreOp.surgeryDate.split('T')[0]);
                // this.consultedSurgeryTypes = this.selectedPreOp.consultedSurgeryTypes;
                let _consultedSurgeryTypes = [];
                let _supplimentedSurgeryTypes = [];
                let _assistantDoctors = [];
                this.selectedPreOp.consultedSurgeryTypes.forEach(element => {
                    _consultedSurgeryTypes.push({ name: element });
                });

                // this.supplimentedSurgeryTypes = this.selectedPreOp.supplimentedSurgeryTypes;
                this.selectedPreOp.supplimentedSurgeryTypes.forEach(element => {
                    _supplimentedSurgeryTypes.push({ name: element });
                });
                // this.assistantDoctors = this.selectedPreOp.assistantDoctors;
                this.selectedPreOp.assistantDoctors.forEach(element => {
                    _assistantDoctors.push({ name: element.split(' ')[0] });
                });

                this.consultedSurgeryTypes = _consultedSurgeryTypes;
                this.supplimentedSurgeryTypes = _supplimentedSurgeryTypes;
                this.assistantDoctors = _assistantDoctors;
            }
            else {
                this.targetWeight = "";
                this.selectedDoctorName = "";
                this.surgeryType = "";
                this.surgeryDate = "";
                this.consultedSurgeryTypes = [];
                this.supplimentedSurgeryTypes = [];
                this.assistantDoctors = [];

            }


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
                this.showEditPreOpModal
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
            } catch (error) {
                console.log(error);
            }
        },
        async _updatePreOp() {
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



            this.setUpdatePreOpCreds({
                targetWeight: parseInt(this.targetWeight),
                doctorId: doctorId,
                surgeryType: this.surgeryType,
                surgeryDate: this.surgeryDate + "T" + new Date(this.surgeryDate).toISOString().split('T')[1],
                consultedSurgeryTypes: _consultedSurgeryTypes,
                supplimentedSurgeryTypes: _supplimentedSurgeryTypes,
                assistantDoctors: _assistantDoctors,
            });
            let response = await this.updatePreOp({ uid: this.selectedPreOp.uId });

            if (response.status === 200 || response.status === 201) {
                this.isError = false;
                this.message = response.data.message;
                this.isSaving = true;
                return true;
            } else {
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
            // if (this.showEditDoctorModal && this.selectedUser == null) {
            //     isDone = await this._updateUser();
            //     if (isDone) {
            //         await this._uploadImage(this.newUserId);
            //     }
            // } else if (this.showEditDoctorModal && this.selectedUser != null) {
            //     isDone = await this._updateUser();
            //     if (isDone) {
            //         await this._uploadImage(this.selectedUser.uId);
            //     }
            // } else if (this.showDeletePersonalModal) {
            //     await this._deleteUser();
            // }

            isDone = await this._updatePreOp();

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
        <Modal title="Edit PreOp" :showModal="showEditPreOpModal" @closeModal="$emit('close-modal')" noPadding fixedHeight
            :md="true">
            <template #content>
                <form class="flex-1 flex flex-col w-full h-full" @submit.prevent="handleForm">
                    <template v-if="currentStep == 1">
                        <div class="border-b flex flex-col gap-4 border-light p-6">
                            <Input v-model="targetWeight" placeholder="Target Weight" outline
                                :error="isError && targetWeight === ''" />
                            <Select outline v-model="selectedDoctorName" placeholder="Select Doctor" :options="doctors"
                                :error="isError && selectedDoctorName === ''" :default-selected="selectedDoctorName" />
                            <Select outline v-model="surgeryType" placeholder="Select Surgery Type" :options="surgeryTypes"
                                :error="isError && surgeryType === ''" :default-selected="surgeryType" />
                            <CreateTagList v-model="supplimentedSurgeryTypes" placeholder="Supplimented Surgery Type"
                                scrollHeight="410px" :options="surgeryTypes" :default-value="supplimentedSurgeryTypes"
                                :error="isError && supplimentedSurgeryTypes.length === 0" />
                            <CreateTagList v-model="consultedSurgeryTypes" placeholder="Consulted Surgery Type"
                                scrollHeight="410px" :options="surgeryTypes" :default-value="consultedSurgeryTypes"
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
                                :options="doctors" :error="isError && assistantDoctors.length === 0"
                                :default-value="assistantDoctors" />
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
                            Edit Pre Op
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