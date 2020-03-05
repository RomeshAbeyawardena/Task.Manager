import Axios from "axios";
const template = require("./index.html");

const defaultComponent = {
    props: {
        getProjectTaskRequestUrl:String,
        getProjectsRequest:String,
        getStatusesRequest:String,
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
            return Axios.get(this.getProjectTaskRequest, data)
                .then(e => context.projectTasks = e.data);
        },
        getProjects(data) {
            const context = this;
            return Axios.get(this.getProjectsRequest, data)
                .then(e => context.projects = e.data);
        },
        getStatuses(data) {
            const context = this;
            return Axios.get(this.getStatusesRequest, data)
                .then(e => context.statuses = e.data);
        }
    }
};

export default defaultComponent;