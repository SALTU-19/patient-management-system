import moment from "moment";

const dateFormatter = (date, flag) => {

    if (!date) return '';

    const tomorrow = moment().add(1, "days").format("L");
    const yesterday = moment().subtract(1, "days").format("L");

    switch (moment(date).format("L")) {
        case yesterday:
            return "Yesterday";
        case tomorrow:
            return "Tomorrow";
        default:
            if (flag) return moment(date).format("DD/MM/YYYY HH:mm");
            else return moment(date).format("L");

    }
};

export default dateFormatter;