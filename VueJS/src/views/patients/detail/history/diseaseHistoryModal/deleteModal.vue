<script>
import InputFile from "@/components/forms/InputFile.vue"
import Modal from "@/components/modals/Modal.vue"
import Input from "@/components/forms/Input.vue"
import { mapActions, mapMutations, mapGetters } from "vuex";
import Select from "@/components/forms/Select.vue"
export default {
    name: "DeleteDiseaseHistoryModal",
    data() {
        return {
            isSaving: false,
            isError: false,
            message: "",
            currentStep: 1,
        };
    },
    components: { InputFile, Modal, Input, Select, },
    props: ["showDeleteDiseaseHistoryModal", "uid"],
    emits: ["close-modal"],
    computed: {

    },
    watch: {
        showDeleteDiseaseHistoryModal(val) {
            if (val) {
                this.currentStep = 1;

            } else {
                this.resetForm();
            }
        },


    },

    methods: {
        ...mapActions(["deleteDiseaseHistory"]),


        handleForm() {
            if (this.currentStep == 2) {
                this.$emit("close-modal");
                this.$emit("is-saving", this.isSaving);
            }
        },
        resetForm() {
            this.isSaving = false;
            this.isError = false;
            this.message = "";
            this.currentStep = 1;
        },
        async _deleteDiseaseHistory() {
            this.isSaving = true;

            let response = await this.deleteDiseaseHistory({ uid: this.uid });

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
            // if (this.showDeleteDoctorModal && this.selectedUser == null) {
            //     isDone = await this._deleteUser();
            //     if (isDone) {
            //         await this._uploadImage(this.newUserId);
            //     }
            // } else if (this.showDeleteDoctorModal && this.selectedUser != null) {
            //     isDone = await this._updateUser();
            //     if (isDone) {
            //         await this._uploadImage(this.selectedUser.uId);
            //     }
            // } else if (this.showDeletePersonalModal) {
            //     await this._deleteUser();
            // }

            isDone = await this._deleteDiseaseHistory();

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
        <Modal title="Delete Disease History" :showModal="showDeleteDiseaseHistoryModal" @closeModal="$emit('close-modal')"
            noPadding fixedHeight :md="true">
            <template #content>
                <form class="flex-1 flex flex-col w-full h-full" @submit.prevent="handleForm">
                    <template v-if="currentStep == 1">
                        <div class="flex-1 flex flex-col justify-center items-center gap-4 w-[500px] mx-auto">
                            <div class="text-center text-2xl font-semibold text-primary">
                                Are you sure you want to delete this
                                disease history?
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
                            v-show="currentStep == 1 || currentStep == 2" @click="finish">
                            Delete
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