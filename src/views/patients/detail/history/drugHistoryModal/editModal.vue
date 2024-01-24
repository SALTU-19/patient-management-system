<script>
import InputFile from "@/components/forms/InputFile.vue"
import Modal from "@/components/modals/Modal.vue"
import Input from "@/components/forms/Input.vue"
import { mapActions, mapMutations, mapGetters } from "vuex";
export default {
    name: "EditDrugHistoryModal",
    data() {
        return {
            name: "",
            startingDate: "",
            endingDate: "",
            doctorComment: "",
            currentStep: 1,
            isSaveHovered: false,
            isSaving: false,
            isError: false,
            message: "",
        };
    },
    components: { InputFile, Modal, Input },
    props: ["showEditDrugHistoryModal", "selectedDrugHistory"],
    emits: ["close-modal"],
    computed: {

    },
    watch: {
        showEditDrugHistoryModal(val) {
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
        ...mapActions(["updateDrugHistory"]),
        ...mapMutations(["setUpdateDrugHistoryCreds"]),

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
            if (this.selectedDrugHistory != null) {
                console.log(this.selectedDrugHistory);
                this.name = this.selectedDrugHistory.name;

                this.startingDate = this.convertDateFormat(this.selectedDrugHistory.startingDate);
                this.endingDate = this.convertDateFormat(this.selectedDrugHistory.endingDate);
                // console.log(this.endingDate + "T" + new Date(this.endingDate).toISOString().split('T')[1]);
                this.doctorComment = this.selectedDrugHistory.doctorComment;
            } else {
                this.name = "";
                this.startingDate = "";
                this.endingDate = "";
                this.doctorComment = "";
            }
            this.isSaving = false;
            this.isError = false;
            this.message = "";
            this.currentStep = 1;
            this.isSaveHovered = false;
        },
        controlFields() {
            if (
                (this.name === "" ||
                    this.startingDate === "" ||
                    this.endingDate === "" ||
                    this.doctorComment === ""
                ) &&
                this.showEditDrugHistoryModal
            ) {
                this.isError = true;
                this.message = "Please fill all the fields!";
            } else {
                this.isError = false;
            }
        },


        async _updateDrugHistory() {
            this.isSaving = true;
            console.log(this.startingDate + "T" + new Date(this.startingDate).toISOString().split('T')[1]);
            console.log(this.startingDate);
            console.log(this.endingDate);
            this.setUpdateDrugHistoryCreds({
                name: this.name,
                startingDate: this.startingDate + "T" + new Date(this.startingDate).toISOString().split('T')[1],
                endingDate: this.endingDate + "T" + new Date(this.endingDate).toISOString().split('T')[1],
                doctorComment: this.doctorComment,
            });
            let response = await this.updateDrugHistory({ uid: this.selectedDrugHistory.uId });

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

            isDone = await this._updateDrugHistory();

            if (isDone) {
                this.currentStep++;
            }
            // this.currentStep++;
        },
    },
    async mounted() {
        // await this._getAllDiseaseHistorys();
        // this.filteredDiseaseHistorys = this.hospitals;
        this.resetForm();
    },
};
</script>

<template>
    <teleport to="body">
        <Modal title="Edit Drug History" :showModal="showEditDrugHistoryModal" @closeModal="$emit('close-modal')" noPadding
            fixedHeight :md="true">
            <template #content>
                <form class="flex-1 flex flex-col w-full h-full" @submit.prevent="handleForm">
                    <template v-if="currentStep == 1">
                        <div class="border-b flex flex-col gap-4 border-light p-6">
                            <Input v-model="name" placeholder="Name" outline :error="isError && name === ''" />
                            <div class="flex flex-col gap-4">
                                <div class="text-black text-sm font-semibold">Starting Date</div>
                                <Input v-model="startingDate" type="date" outline :error="isError && startingDate === ''" />
                            </div>
                            <div class="flex flex-col gap-4">
                                <div class="text-black text-sm font-semibold">Ending Date</div>
                                <Input v-model="endingDate" type="date" outline :error="isError && endingDate === ''" />
                            </div>
                            <Input v-model="doctorComment" placeholder="Doctor Comment" outline
                                :error="isError && doctorComment === ''" />
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
                            Edit Drug History
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