import { createStore } from "vuex";
import axios from "axios";
import diseaseModule from "./disease";
import drugModule from "./drug";
import hospitalModule from "./hospital";
import irregularVisitModule from "./irregularVisit";
import organizationModule from "./organization";
import patientModule from "./patient";
import periodicVisitModule from "./periodicVisit";
import postOpModule from "./postOp";
import preOpModule from "./preOp";
import surgeryModule from "./surgery";
import userModule from "./user";

export default createStore({
    modules: {
        diseaseModule,
        drugModule,
        hospitalModule,
        irregularVisitModule,
        organizationModule,
        patientModule,
        periodicVisitModule,
        postOpModule,
        preOpModule,
        surgeryModule,
        userModule,
    },
});
