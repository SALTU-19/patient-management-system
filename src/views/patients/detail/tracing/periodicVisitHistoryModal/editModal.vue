<script>
import InputFile from "@/components/forms/InputFile.vue"
import Modal from "@/components/modals/Modal.vue"
import CreateTagList from "@/components/forms/CreateTagList.vue"
import Select from "@/components/forms/Select.vue"
import Input from "@/components/forms/Input.vue"
import PdfFile from "@/components/forms/PdfFile.vue"
import ImageFile from "@/components/forms/ImageFile.vue"
import IconTrash from "@/components/icons/IconTrash.vue"
import { mapActions, mapMutations, mapGetters } from "vuex";
export default {
    name: "EditPeriodicVisitHistoryModal",
    data() {
        return {
            vki: "",
            ewl: "",
            doctorComment: "",
            date: "",
            bloodSituation: null,
            newImage: null,
            currentStep: 1,
            isSaveHovered: false,
            isSaving: false,
            isError: false,
            message: "",
            patientImages: [],

        };
    },
    components: {
        InputFile,
        Modal,
        CreateTagList,
        Input,
        Select,
        PdfFile,
        ImageFile,
        IconTrash,
    },
    props: ["showEditPeriodicVisitHistoryModal", "selectedPeriodicVisitHistory"],
    emits: ["close-modal"],
    watch: {
        showEditPeriodicVisitHistoryModal(val) {
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
        newImage(val) {
            if (val) {
                this.patientImages.push(val);
            }
        },



    },
    methods: {
        ...mapActions(["updatePeriodicVisitHistory"]),
        ...mapMutations(["setUpdatePeriodicVisitHistoryCreds"]),

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
            if (this.selectedPeriodicVisitHistory != null) {
                this.vki = this.selectedPeriodicVisitHistory.vki;
                this.ewl = this.selectedPeriodicVisitHistory.ewl;
                this.doctorComment = this.selectedPeriodicVisitHistory.doctorComment;
                this.date = this.convertDateFormat(this.selectedPeriodicVisitHistory.date);
                // this.bloodSituation = this.selectedPeriodicVisitHistory.bloadSituation;
                this.bloodSituation = {
                    base64: this.selectedPeriodicVisitHistory.bloadSituation,
                    name: "bloodSituation",
                }
                this.patientImages = this.selectedPeriodicVisitHistory.img;
                this.newImage = null;
            }
            else {
                this.vki = "";
                this.ewl = "";
                this.doctorComment = "";
                this.date = "";
                this.bloodSituation = null;
                this.patientImages = [];
                this.newImage = null;
            }


            this.isSaving = false;
            this.isError = false;
            this.message = "";
            this.currentStep = 1;
            this.isSaveHovered = false;
        },
        controlFields() {

            if (
                (this.vki === "" ||
                    this.ewl === "" ||
                    this.doctorComment === "" ||
                    // this.blodSituation === null ||
                    this.date === ""
                ) &&
                this.showEditPeriodicVisitHistoryModal
            ) {


                this.isError = true;
                this.message = "Please fill all the fields!";
            } else {
                this.isError = false;
            }
        },


        async _updatePeriodicVisitHistory() {
            this.isSaving = true;




            this.setUpdatePeriodicVisitHistoryCreds({
                vki: parseInt(this.vki),
                ewl: parseInt(this.ewl),
                doctorComment: this.doctorComment,
                date: this.date + "T" + new Date(this.date).toISOString().split('T')[1],
                img: this.patientImages,
                bloadSituation: this.bloodSituation.base64,
            });
            let response = await this.updatePeriodicVisitHistory({ uid: this.selectedPeriodicVisitHistory.uId });

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

            isDone = await this._updatePeriodicVisitHistory();

            if (isDone) {
                this.currentStep++;
            }
            // this.currentStep++;
        },

        flushImage(index) {
            this.patientImages.splice(index, 1);
        },


    },
    async mounted() {

        this.resetForm();
    },
};
</script>

<template>
    <teleport to="body">
        <Modal title="Edit Periodic Visit History" :showModal="showEditPeriodicVisitHistoryModal"
            @closeModal="$emit('close-modal')" noPadding fixedHeight :md="true">
            <template #content>
                <form class="flex-1 flex flex-col w-full h-full" @submit.prevent="handleForm">
                    <template v-if="currentStep == 1">
                        <div class="border-b flex flex-col gap-4 border-light p-6">
                            <div class="flex flex-row gap-4">
                                <Input v-model="vki" placeholder="VKI" outline :error="isError && vki === ''" />
                                <Input v-model="ewl" placeholder="EWL" outline :error="isError && ewl === ''" />
                            </div>
                            <div class="flex flex-row gap-4">

                                <div class="text-black text-sm font-semibold">Date</div>
                                <Input v-model="date" type="date" placeholder="Date" outline
                                    :error="isError && date === ''" />

                            </div>
                            <Input v-model="doctorComment" placeholder="Doctor Comment" outline
                                :error="isError && doctorComment === ''" />
                            <div class="flex flex-row gap-4">
                                <div class="flex flex-col gap-4">
                                    <div class="text-black text-sm font-semibold">Upload Blood Situation (PDF)</div>
                                    <PdfFile class="mx-auto" @new-pdf="bloodSituation = $event"
                                        :initial-base64="bloodSituation.base64" />
                                </div>
                            </div>
                            <div class="flex flex-row gap-4">
                                <div class="flex flex-col gap-4">
                                    <div class="text-black text-sm font-semibold">Upload User Images</div>
                                    <ImageFile class="mx-auto" @new-image="newImage = $event" />
                                </div>
                            </div>

                            <!-- i want to print added images iterate patient images array -->
                            <div v-if="patientImages.length > 0">
                                <div class="text-black text-sm font-semibold">Edited Images</div>
                                <div class="flex flex-row gap-4">

                                    <div v-for="(image, index) in patientImages" :key="index" class="flex flex-col gap-4">
                                        <button class="flex justify-center items-center ml-28 w-3 h-3"
                                            @click="flushImage(index)" type="button">
                                            <IconTrash />
                                        </button>
                                        <img :src="image" alt="Edited Image" class="mx-auto"
                                            style="max-width: 100px; max-height: 100px;" />

                                    </div>
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
                            Edit
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