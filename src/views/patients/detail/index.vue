<script>
import ContentPanel from '@/components/layout/ContentPanel.vue';
import IconBack from '@/components/icons/IconBack.vue';
import PatientInfo from '@/components/patientInfo/index.vue';
import Card from '@/components/cards/Card.vue';
import { mapActions } from 'vuex';
import { AtomSpinner } from 'epic-spinners';
export default {
    name: 'PatientDetail',
    components: {
        ContentPanel,
        IconBack,
        PatientInfo,
        Card,
        AtomSpinner,
    },
    props: {},
    data() {
        return {
            id: this.$route.params.id,
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
            isLoading: true,
        }
    },
    computed: {

    },
    methods: {
        ...mapActions(['getPatient']),

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

            this.isLoading = false;
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
            <div class="flex items-center justify-center cursor-pointer" @click="$router.go(-1)">
                <div class="w-8 h-8 flex items-center justify-center ">
                    <IconBack />
                </div>
                <div class="ml-4">Go Back</div>
            </div>
        </template>
        <template #content>
            <div v-if="isLoading" class="flex justify-center items-center h-[500px]">
                <AtomSpinner :color="'#BEEBE5'" :animation-duration="1000" />
            </div>
            <div v-if="!isLoading">
                <PatientInfo :antropometric-contents="antropometricContents" :demographic-contents="demographicContents"
                    :image="image" />
                <div class="mx-10 grid grid-cols-3 gap-4 my-10">
                    <div class="...">
                        <Card icon="@/components/assets/TimeProgress.png" title="HISTORY"
                            @click="$router.push(`/patients/${id}/history`)" />
                    </div>
                    <div class="...">
                        <Card icon="@/components/assets/TimeProgress.png" title="PRE-OP"
                            @click="$router.push(`/patients/${id}/preop`)" />
                    </div>
                    <div class="...">
                        <Card icon="@/components/assets/TimeProgress.png" title="POST-OP"
                            @click="$router.push(`/patients/${id}/postop`)" />
                    </div>
                    <div class="...">
                        <Card icon="@/components/assets/TimeProgress.png" title="TRACING"
                            @click="$router.push(`/patients/${id}/tracing`)" />
                    </div>
                </div>
            </div>
        </template>
    </ContentPanel>
</template>
<style lang="scss" scoped></style>