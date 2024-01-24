
import { createRouter, createWebHistory } from 'vue-router'
// import store from '../store'

const routes = [
    {
        path: '/',
        name: "doctors",
        component: () =>
            import("@/views/doctors/list/index.vue"),
    },
    {
        path: '/schedule',
        name: "schedule",
        component: () =>
            import("@/views/schedule/list/index.vue"),
    },
    {
        path: '/patients',
        name: "patient",
        component: () =>
            import("@/views/patients/list/index.vue"),
    },
    {
        path: '/patients/:id',
        name: "PatientDetail",
        component: () =>
            import("@/views/patients/detail/index.vue"),

    },
    {
        path: '/patients/:id/history',
        name: "PatientHistory",
        component: () =>
            import("@/views/patients/detail/history/index.vue"),

    },
    {
        path: '/patients/:id/preop',
        name: "PatientPreop",
        component: () =>
            import("@/views/patients/detail/preop/index.vue"),

    },
    {
        path: '/patients/:id/postop',
        name: "PatientPostop",
        component: () =>
            import("@/views/patients/detail/postop/index.vue"),

    },
    {
        path: '/patients/:id/tracing',
        name: "PatientTracing",
        component: () =>
            import("@/views/patients/detail/tracing/index.vue"),

    },
    {
        path: '/hospitals',
        name: "laboratory",
        component: () =>
            import("@/views/hospitals/list/index.vue"),
    },
    // {
    //     path: '/login',
    //     name: 'Login',
    //     component: () => import('find/views/Login.vue'),
    //     meta: {
    //         guest: true
    //     }
    // },
    // {
    //     path: '/register',
    //     name: 'Register',
    //     component: () => import('find/views/Register.vue'),
    //     meta: {
    //         guest: true
    //     }
    // },
    // {
    //     path: '/profile',
    //     name: 'Profile',
    //     component: () => import('find/views/Profile.vue'),
    //     meta: {
    //         requiresAuth: true
    //     }
    // },
    // {
    //     path: '/:pathMatch(.*)*',
    //     name: 'NotFound',
    //     component: () => import('find/views/NotFound.vue')
    // }
]

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes,
    scrollBehavior() {
        return { top: 0 };
    },
});

export default router;

