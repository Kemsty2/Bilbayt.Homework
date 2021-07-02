import { createSelector } from "reselect";
export const selectUser = (state) => state.user;

export const selectUserProfile = createSelector(
  selectUser,
  (user) => user.profile
);
