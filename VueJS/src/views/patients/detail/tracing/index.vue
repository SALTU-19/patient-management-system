
<script>
import ContentPanel from '@/components/layout/ContentPanel.vue';
import IconBack from '@/components/icons/IconBack.vue';
import PatientInfo from '@/components/patientInfo/index.vue';
import Card from '@/components/cards/Card.vue';
import tabBar from '@/components/blocks/tabBar.vue';
import PeriodicVisitHistoryCard from '@/components/cards/PeriodicVisitHistoryCard.vue';
import IrregularVisitHistoryCard from '@/components/cards/IrregularVisitHistoryCard.vue';
import tracingMenuList from '@/data/tracingMenu';
import { mapActions } from 'vuex';
import AddPeriodicVisitHistoryModal from '@/views/patients/detail/tracing/periodicVisitHistoryModal/addModal.vue';
import EditPeriodicVisitHistoryModal from '@/views/patients/detail/tracing/periodicVisitHistoryModal/editModal.vue';
import DeletePeriodicVisitHistoryModal from '@/views/patients/detail/tracing/periodicVisitHistoryModal/deleteModal.vue';
import AddIrregularVisitHistoryModal from '@/views/patients/detail/tracing/irregularVisitHistoryModal/addModal.vue';
import EditIrregularVisitHistoryModal from '@/views/patients/detail/tracing/irregularVisitHistoryModal/editModal.vue';
import DeleteIrregularVisitHistoryModal from '@/views/patients/detail/tracing/irregularVisitHistoryModal/deleteModal.vue';
import { AtomSpinner } from 'epic-spinners';
export default {
    name: 'PatientTracing',
    components: {
        ContentPanel,
        IconBack,
        PatientInfo,
        Card,
        tabBar,
        PeriodicVisitHistoryCard,
        IrregularVisitHistoryCard,
        AddPeriodicVisitHistoryModal,
        EditPeriodicVisitHistoryModal,
        DeletePeriodicVisitHistoryModal,
        AddIrregularVisitHistoryModal,
        EditIrregularVisitHistoryModal,
        DeleteIrregularVisitHistoryModal,
        AtomSpinner,
    },
    props: {},
    data() {
        return {
            id: this.$route.params.id,
            title: 'TRACING',
            selectedMenuItem: 1,
            tracingMenuList: tracingMenuList,
            periodicVisits: [
                {
                    id: 1,
                    month: '1st Month',
                    date: '12.12.2020',
                    status: 'Completed',
                },
                {
                    id: 2,
                    month: '2nd Month',
                    date: '12.12.2020',
                    status: 'Completed',
                },
            ],
            irregularVisits: [
                {
                    id: 1,
                    month: '1st Month',
                    date: '12.12.2020',
                    status: 'Completed',
                },
                {
                    id: 2,
                    month: '2nd Month',
                    date: '12.12.2020',
                    status: 'Completed',
                },
            ],
            buttonTitle: 'Add History',
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
            showAddPeriodicVisitHistoryModal: false,
            showEditPeriodicVisitHistoryModal: false,
            showDeletePeriodicVisitHistoryModal: false,
            showAddIrregularVisitHistoryModal: false,
            showEditIrregularVisitHistoryModal: false,
            showDeleteIrregularVisitHistoryModal: false,
            uid: null,
            isSaving: false,
            selectedPeriodicVisitHistory: null,
            selectedIrregularVisitHistory: null,
            isLoading: true,
        }
    },
    computed: {

    },
    methods: {
        ...mapActions(['getPatient']),

        convertDateFormat(inputDateString) {
            // Create a new Date object using the input date string
            var dateObject = new Date(inputDateString);

            // Get the individual components of the date
            var day = dateObject.getUTCDate();
            var month = dateObject.getUTCMonth() + 1; // Months are zero-based, so we add 1
            var year = dateObject.getUTCFullYear();

            // Format the date components in "DD.MM.YYYY" format
            var formattedDate = `${day}.${month}.${year}`;

            return formattedDate;
        },
        checkEditPeriodicVisitHistory(val, item) {
            if (val) {
                this.selectedPeriodicVisitHistory = item;
                this.showEditPeriodicVisitHistoryModal = true;
            }
        },
        checkEditIrregularVisitHistory(val, item) {
            if (val) {
                this.selectedIrregularVisitHistory = item;
                this.showEditIrregularVisitHistoryModal = true;
            }
        },
        checkDeletePeriodicVisitHistory(val, item) {
            if (val) {
                this.uid = item.uId;
                this.showDeletePeriodicVisitHistoryModal = true;
            }
        },
        checkDeleteIrregularVisitHistory(val, item) {
            if (val) {
                this.uid = item.uId;
                this.showDeleteIrregularVisitHistoryModal = true;
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

            this.periodicVisits = response.periodicVisitHistory;
            this.irregularVisits = response.irregularVisitHistory;
            let i = 0;
            this.periodicVisits.forEach((element) => {
                element.date = this.convertDateFormat(element.date);
                // element.month = this.calculateMonthDifference(new Date(element.date), new Date());
                element.month = i + 1 + "st Month";
                element.status = "Completed";
                i++;
            });

            this.irregularVisits.forEach((element) => {
                element.date = this.convertDateFormat(element.date);
                // element.month = this.calculateMonthDifference(new Date(element.date), new Date());
                element.status = "Completed";
                i++;
            });

            this.isLoading = false;
        },
        clickAddHistory() {
            // this.showAddPeriodicVisitHistoryModal = true;
            if (this.selectedMenuItem == 1) {
                this.showAddPeriodicVisitHistoryModal = true;
            } else if (this.selectedMenuItem == 2) {
                this.showAddIrregularVisitHistoryModal = true;
            }
        },


    },
    async mounted() {
        this.id = this.$route.params.id;
        this.buttonTitle = '+ Add Periodic Visit ';

        await this._getPatient();

        console.log(this.id);

    },
    watch: {
        async isSaving(val) {
            if (this.isSaving) {
                await this._getPatient();
                this.isSaving = false;
            }
            // await this._getAllUsers();
        },
        selectedMenuItem: function (val) {
            if (val == 1) {
                this.buttonTitle = '+ Add Periodic Visit ';
            } else if (val == 2) {
                this.buttonTitle = '+ Add Irregular Visit';
            }
        }
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
                    <div class="flex flex-row justify-between items-center">
                        <tabBar @selected-menu-item="selectedMenuItem = $event" :menuList="tracingMenuList" />
                        <button class="bg-primary text-black rounded-2xl px-4 py-2 " @click="clickAddHistory">{{ buttonTitle
                        }}</button>
                    </div>
                </div>
                <div v-if="selectedMenuItem == 1" class="flex flex-col gap-6 mt-6 overflow-y-auto"
                    style="max-height: 300px;">
                    <PeriodicVisitHistoryCard v-for="periodicVisit in periodicVisits" :key="periodicVisit.id"
                        :periodicVisit="periodicVisit" @edit="checkEditPeriodicVisitHistory($event, periodicVisit)"
                        @delete="checkDeletePeriodicVisitHistory($event, periodicVisit)" />
                </div>
                <div v-if="selectedMenuItem == 2" class="flex flex-col gap-6 mt-6 overflow-y-auto"
                    style="max-height: 300px;">
                    <IrregularVisitHistoryCard v-for="irregularVisit in irregularVisits" :key="irregularVisit.id"
                        :irregularVisit="irregularVisit" @edit="checkEditIrregularVisitHistory($event, irregularVisit)"
                        @delete="checkDeleteIrregularVisitHistory($event, irregularVisit)" />
                </div>
            </div>
        </template>
    </ContentPanel>
    <AddPeriodicVisitHistoryModal :showAddPeriodicVisitHistoryModal="showAddPeriodicVisitHistoryModal" :patientUID="id"
        @close-modal="showAddPeriodicVisitHistoryModal = false" @is-saving="isSaving = $event" />
    <EditPeriodicVisitHistoryModal :showEditPeriodicVisitHistoryModal="showEditPeriodicVisitHistoryModal"
        :selectedPeriodicVisitHistory="selectedPeriodicVisitHistory"
        @close-modal="showEditPeriodicVisitHistoryModal = false" @is-saving="isSaving = $event" />
    <DeletePeriodicVisitHistoryModal :showDeletePeriodicVisitHistoryModal="showDeletePeriodicVisitHistoryModal" :uid="uid"
        @close-modal="showDeletePeriodicVisitHistoryModal = false" @is-saving="isSaving = $event" />

    <AddIrregularVisitHistoryModal :showAddIrregularVisitHistoryModal="showAddIrregularVisitHistoryModal" :patientUID="id"
        @close-modal="showAddIrregularVisitHistoryModal = false" @is-saving="isSaving = $event" />
    <EditIrregularVisitHistoryModal :showEditIrregularVisitHistoryModal="showEditIrregularVisitHistoryModal"
        :selectedIrregularVisitHistory="selectedIrregularVisitHistory"
        @close-modal="showEditIrregularVisitHistoryModal = false" @is-saving="isSaving = $event" />
    <DeleteIrregularVisitHistoryModal :showDeleteIrregularVisitHistoryModal="showDeleteIrregularVisitHistoryModal"
        :uid="uid" @close-modal="showDeleteIrregularVisitHistoryModal = false" @is-saving="isSaving = $event" />
</template>
<style lang="scss" scoped></style>