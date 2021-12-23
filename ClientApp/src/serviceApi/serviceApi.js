import axios from "axios";

function GetAllCompanies() {
  return axios.get("/api/companies/my").then((res) => {
    return res.data;
  });
}

function GetRequestedCompany(registryCode) {
  return axios.post("/api/companies", { registryCode: registryCode }).then((res) => {
    return res.data;
  });
}

const API = {
  GetAllCompanies,
  GetRequestedCompany,
};

export default API;
