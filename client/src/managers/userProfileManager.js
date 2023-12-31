const _apiUrl = "/api/userprofile";

export const getUserProfilesWithRoles = () => {
  return fetch(_apiUrl + "/withroles").then((res) => res.json());
};

export const getInactiveUserProfilesWithRoles = () => {
  return fetch(_apiUrl + "/withroles/inactive").then((res) => res.json());
}

export const getUserById = (id) => {
  return fetch(_apiUrl + `/${id}`).then((res) => res.json());
};

export const deactivateUserById = (id) => {
  return fetch(_apiUrl + `/${id}`, {
    method: "DELETE"
  });
};

export const reactivateUserById = (id) => {
  return fetch(_apiUrl + `/${id}/reactivate`, {
    method: "DELETE"
  });
};