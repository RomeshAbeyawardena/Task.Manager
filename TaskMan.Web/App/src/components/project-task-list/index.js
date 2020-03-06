import Axios from "axios";
const template = require("./index.html");

const defaultComponent = {
    template: template,
    props: {
        getProjectTaskRequestUrl: String,
        getProjectsRequestUrl: String,
        getStatusesRequestUrl: String,
        projectTextId: String,
        projectValueId: String,
        statusTextId: String,
        statusValueId: String
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

            if(!this.getProjectTaskRequestUrl)
                return;

            return Axios.get(this.getProjectTaskRequestUrl, data)
                .then(e => context.projectTasks = e.data, this.onError);
        },
        getProjects(data) {
            const context = this;

            if(!this.getProjectsRequestUrl)
                return;

            return Axios.get(this.getProjectsRequestUrl, data)
                .then(e => context.projects = e.data, this.onError);
        },
        getStatuses(data) {
            const context = this;

            if(!this.getStatusesRequestUrl)
                return;

            return Axios.get(this.getStatusesRequestUrl, data)
                .then(e => context.statuses = e.data, this.onError);
        },
        onError(e) {
            this.$emit("data:error", e);
        }
    },
    created() {
        this.getProjectTaskRequest();
        this.getProjects();
        this.getStatuses();
    }
};

export default defaultComponent;