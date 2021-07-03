import { createSelector } from "reselect";
export const selectUser = (state) => state.users;

export const selectUserProfile = createSelector(
  selectUser,
  (users) => users.profile
);

export const selectUserIsAuthenticated = createSelector(
  selectUser,
  (users) => users.isAuthenticated
);

export const selectUserToken = createSelector(
  selectUser,
  (users) => users.token
);
