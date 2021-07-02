import { combineReducers } from "redux";
import { connectRouter } from "connected-react-router";

import messagesReducer from "./messages/messages.reducer";
import usersReducer from "./users/users.reducers";

const createRootReducer = (history) =>
  combineReducers({
    messages: messagesReducer,
    users: usersReducer,
    router: connectRouter(history),
  });

export default createRootReducer;
