import Axios from "axios";
const template = require("./index.html");

const defaultComponent = {
    props: {
        getProjectTaskRequestUrl:String,
        getProjectsRequestUrl:String,
        getStatusesRequestUrl:String,
        projectTextId:String,
        projectValueId:String,
        statusTextId:String,
        statusValueId:String
    },
    data() {
        return {
            projectTasks: [],
            projects: [],
            statuses: []
        };
    },
    methods: {
        getProjectTaskRequest(data) {
            const context = this;
            return Axios.get(this.getProjectTaskRequestUrl, data)
                .then(e => context.projectTasks = e.data);
        },
        getProjects(data) {
            const context = this;
            return Axios.get(this.getProjectsRequestUrl, data)
                .then(e => context.projects = e.data);
        },
        getStatuses(data) {
            const context = this;
            return Axios.get(this.getStatusesRequestUrl, data)
                .then(e => context.statuses = e.data);
        }
    }
};

export default defaultComponent;