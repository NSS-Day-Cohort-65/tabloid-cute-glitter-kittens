const _apiUrl = "/api/userprofile";

export const getUserProfilesWithRoles = () => {
  return fetch(_apiUrl + "/withroles").then((res) => res.json());
};

export const getUserById = (id) => {
  return fetch(_apiUrl + `/${id}`).then((res) => res.json());
};
