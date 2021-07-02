import { createSelector } from "reselect";

export const selectMessages = (state) => state.messages;

export const selectGlobalMessage = createSelector(
  selectMessages,
  (messages) => messages.message
);

export const selectGlobalStatus = createSelector(
  selectMessages,
  (messages) => messages.status
);
