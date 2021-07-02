import API from "../../../utils/API";

export const loginApi = (loginData) => {
  return new Promise((resolve, reject) => {
    API.post("/accounts/login", loginData)
      .then((res) => {
        resolve(res.data.result);
      })
      .catch((err) => {
        reject(err);
      });
  });
};

export const registerApi = ({ userName, fullName, password }) => {
  return new Promise((resolve, reject) => {
    API.post("/accounts/signup", { userName, fullName, password })
      .then((res) => {
        resolve(res.data.result);
      })
      .catch((err) => {
        reject(err);
      });
  });
};

export const getProfileApi = () => {
  return new Promise((resolve, reject) => {
    API.get("/accounts/profile")
      .then((res) => {
        resolve(res.data.result);
      })
      .catch((err) => {
        reject(err);
      });
  });
};
