
import { createRouter, createWebHistory } from 'vue-router'
// import store from '../store'

const routes = [
    {
        path: "/sign-in",
        name: "SignIn",
        component: () => import(/* webpackChunkName: "sign-in" */ "../views/auth/sign-in.vue"),
        meta: {
            layout: "Auth",
        },
    },
    {
        path: '/',
        name: "doctors",
        component: () =>
            import("@/views/doctors/list/index.vue"),
        beforeEnter: (to, from, next) => {
            const user = localStorage.getItem("user");
            if (user) {
                next();
            } else {
                next("/sign-in");
            }
        }
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
]

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes,
    scrollBehavior() {
        return { top: 0 };
    },
});

export default router;

