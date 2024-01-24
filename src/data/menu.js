import IconPatient from '@/components/icons/IconPatient.vue';
import IconSchedule from '@/components/icons/IconSchedule.vue';
import IconDoctor from '@/components/icons/IconDoctor.vue';
import IconHospital from '@/components/icons/IconHospital.vue';
import { shallowRef } from 'vue';

const menuList = [
    {
        id: 1,
        name: 'Doctor',
        path: '/',
        icon: shallowRef(IconDoctor),
        text: 'Doctor',
    },
    {
        id: 2,
        name: 'Schedule',
        path: '/schedule',
        icon: shallowRef(IconSchedule),
        text: 'Schedule',
    },
    {
        id: 3,
        name: 'Patient',
        path: '/patients',
        icon: shallowRef(IconPatient),
        text: 'Patient',
    },
    {
        id: 4,
        name: 'Hospital',
        path: '/hospitals',
        icon: shallowRef(IconHospital),
        text: 'Hospital',
    },
];

export default menuList;