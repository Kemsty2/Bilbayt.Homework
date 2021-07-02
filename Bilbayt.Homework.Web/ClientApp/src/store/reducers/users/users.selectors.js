import { createSelector } from "reselect";
import { getName } from "../../../utils";

export const selectUser = (state) => state.user;

export const selectUserProfile = createSelector(
  selectUser,
  (user) => user.profile
);

export const selectUsername = createSelector(selectUserProfile, (profile) =>
  profile.userName
);
