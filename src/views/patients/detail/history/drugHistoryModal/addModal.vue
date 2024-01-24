<script>
import InputFile from "@/components/forms/InputFile.vue"
import Modal from "@/components/modals/Modal.vue"
import Input from "@/components/forms/Input.vue"
import { mapActions, mapMutations, mapGetters } from "vuex";
export default {
    name: "AddDrugHistoryModal",
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
    props: ["showAddDrugHistoryModal", "patientUID"],
    emits: ["close-modal"],
    computed: {

    },
    watch: {
        showAddDrugHistoryModal(val) {
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
        ...mapActions(["createDrugHistory"]),
        ...mapMutations(["setCreateDrugHistoryCreds"]),

        handleForm() {
            if (this.currentStep == 2) {
                this.$emit("close-modal");
                this.$emit("is-saving", this.isSaving);
            }
        },
        resetForm() {
            this.name = "";
            this.startingDate = "";
            this.endingDate = "";
            this.doctorComment = "";
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
                this.showAddDrugHistoryModal
            ) {
                this.isError = true;
                this.message = "Please fill all the fields!";
            } else {
                this.isError = false;
            }
        },


        async _createDrugHistory() {
            this.isSaving = true;
            this.setCreateDrugHistoryCreds({
                name: this.name,
                startingDate: this.startingDate + "T" + new Date(this.startingDate).toISOString().split('T')[1],
                endingDate: this.endingDate + "T" + new Date(this.endingDate).toISOString().split('T')[1],
                doctorComment: this.doctorComment,
                patientUID: this.patientUID,
            });
            let response = await this.createDrugHistory();

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

            isDone = await this._createDrugHistory();

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
        <Modal title="Add Drug History" :showModal="showAddDrugHistoryModal" @closeModal="$emit('close-modal')" noPadding
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
                            Add Drug History
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