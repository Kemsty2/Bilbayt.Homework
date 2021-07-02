import { createSelector } from "reselect";
export const selectUser = (state) => state.users;

export const selectUserProfile = createSelector(
  selectUser,
  (users) => users.profile
);
