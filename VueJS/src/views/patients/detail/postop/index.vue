
<script>
import ContentPanel from '@/components/layout/ContentPanel.vue';
import IconBack from '@/components/icons/IconBack.vue';
import PatientInfo from '@/components/patientInfo/index.vue';
import Card from '@/components/cards/Card.vue';
import PostOpCard from '@/components/cards/PostOpCard.vue';
import AddPostOpModal from "@/views/patients/detail/postop/modal/addModal.vue";
import EditPostOpModal from "@/views/patients/detail/postop/modal/editModal.vue";
import DeletePostOpModal from "@/views/patients/detail/postop/modal/deleteModal.vue";
import { mapActions } from 'vuex';
import { AtomSpinner } from 'epic-spinners';
export default {
    name: 'PatientPostop',
    components: {
        ContentPanel,
        IconBack,
        PatientInfo,
        Card,
        PostOpCard,
        AddPostOpModal,
        EditPostOpModal,
        DeletePostOpModal,
        AtomSpinner,
    },
    props: {},
    data() {
        return {
            id: this.$route.params.id,
            title: 'POST-OP',
            selectedMenuItem: 1,
            showAddPostOpModal: false,
            showEditPostOpModal: false,
            showDeletePostOpModal: false,
            selectedPostOp: null,
            uid: null,
            postOpList: [
                {
                    id: 1,
                    surgeryDate: '12.12.2020',
                    doctorComment: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. ',
                },
                {
                    id: 2,
                    surgeryDate: '12.12.2020',
                    doctorComment: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
                },
                {
                    id: 3,
                    surgeryDate: '12.12.2020',
                    doctorComment: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
                },
                {
                    id: 4,
                    surgeryDate: '12.12.2020',
                    doctorComment: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
                },
                {
                    id: 5,
                    surgeryDate: '12.12.2020',
                    doctorComment: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit.',
                },
            ],
            demographicContents: {
                Age: 32,
                Sex: "Female",
                Name: "Ali",
                Surname: "Veli",
                Phone: "05555555555",
                Address: "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
            },
            antropometricContents: {
                Size: "180 cm",
                Weight: "80 kg",
                BMI: "24.69",
                BodyMass: "Normal",
            },
            image: "",
            isSaving: false,
            doctor: "",
            isLoading: true,
        }
    },
    computed: {

    },
    methods: {
        ...mapActions(['getPatient', 'getUser']),
        convertDateFormat(inputDateString) {
            // Create a new Date object using the input surgeryDate string
            var surgeryDateObject = new Date(inputDateString);

            // Get the individual components of the surgeryDate
            var day = surgeryDateObject.getUTCDate();
            var month = surgeryDateObject.getUTCMonth() + 1; // Months are zero-based, so we add 1
            var year = surgeryDateObject.getUTCFullYear();

            // Format the surgeryDate components in "DD.MM.YYYY" format
            var formattedDate = `${day}.${month}.${year}`;

            return formattedDate;
        },
        checkEdit(val, item) {
            if (val) {
                this.selectedPostOp = item;
                this.showEditPostOpModal = true;
            }
        },
        checkDelte(val, item) {
            if (val) {
                this.uid = item.uId;
                this.showDeletePostOpModal = true;
            }
        },
        async _getPatient() {

            this.isLoading = true;

            const response = await this.getPatient({ uid: this.id });


            this.demographicContents.Address = response.address;
            this.demographicContents.Age = response.age;
            this.demographicContents.Name = response.name;
            this.demographicContents.Surname = response.surname;
            this.demographicContents.Phone = response.phone;
            this.demographicContents.Sex = "Male";

            this.antropometricContents.BMI = response.bmi;
            this.antropometricContents.BodyMass = response.bodyMassIndex;
            this.antropometricContents.Size = response.size.toString() + " cm";
            this.antropometricContents.Weight = response.weight.toString() + " kg";

            this.image = response.image;

            this.postOpList = response.postOps;
            if (this.postOpList.length > 0) {
                this.postOpList.forEach(async (element) => {
                    element.surgeryDate = this.convertDateFormat(element.surgeryDate);
                    this.doctor = await this.getUser({ uid: element.doctorId });
                    element.doctorName = this.doctor.name;
                    element.patientName = this.demographicContents.Name + " " + this.demographicContents.Surname;
                });
            }

            this.isLoading = false;
        },

    },
    watch: {
        async isSaving(val) {
            if (this.isSaving) {
                await this._getPatient();
                this.isSaving = false;
            }
            // await this._getAllUsers();
        },
    },
    async mounted() {
        this.id = this.$route.params.id;


        await this._getPatient();

        console.log(this.id);

    },
};
</script>
<template>
    <ContentPanel>
        <template #header>
            <div class="flex flex-row items-center justify-between">
                <div class="flex items-center justify-center cursor-pointer" @click="$router.go(-1)">
                    <div class="w-8 h-8 flex items-center justify-center ">
                        <IconBack />
                    </div>
                    <div class="ml-4">Go Back</div>

                </div>
                <div class="font-semibold ml-96 ">{{ title }}</div>
            </div>
        </template>
        <template #content>
            <div v-if="isLoading" class="flex justify-center items-center h-[500px]">
                <AtomSpinner :color="'#BEEBE5'" :animation-duration="1000" />
            </div>
            <div v-if="!isLoading">
                <div class="flex flex-col gap-6">
                    <PatientInfo :antropometric-contents="antropometricContents" :demographic-contents="demographicContents"
                        :image="image" />
                    <div class="flex flex-row justify-end items-center">

                        <button class="bg-primary text-black rounded-2xl px-4 py-2 " @click="showAddPostOpModal = true">+
                            Add
                            Post-Op</button>
                    </div>
                </div>
                <div class="flex flex-col gap-6 mt-6 overflow-y-auto" style="max-height: 300px;">
                    <PostOpCard v-for="postOp in postOpList" :key="postOp.id" :postOp="postOp"
                        @edit="checkEdit($event, postOp)" @delete="checkDelte($event, postOp)" />
                </div>
            </div>
        </template>
    </ContentPanel>
    <AddPostOpModal :showAddPostOpModal="showAddPostOpModal" :patientUID="id" @close-modal="showAddPostOpModal = false"
        @is-saving="isSaving = $event" />
    <EditPostOpModal :showEditPostOpModal="showEditPostOpModal" :patientUID="id" :selectedPostOp="selectedPostOp"
        @close-modal="showEditPostOpModal = false" @is-saving="isSaving = $event" />
    <DeletePostOpModal :showDeletePostOpModal="showDeletePostOpModal" :uid="uid"
        @close-modal="showDeletePostOpModal = false" @is-saving="isSaving = $event" />
</template>
<style lang="scss" scoped></style>