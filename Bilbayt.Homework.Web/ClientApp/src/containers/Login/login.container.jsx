import { useState } from "react";
import { connect } from "react-redux";
import { useHistory } from "react-router";

import LoginPage from "../../pages/Login/login.page";
import { loginAsync } from "../../store/reducers/users/users.action";

const LoginContainer = ({ loginAsync }) => {
  const [isLoading, setIsLoading] = useState(false);
  const history = useHistory();

  const handleSubmit = (data) => {
    setIsLoading(true);

    loginAsync(data)
      .then(() => {
        setIsLoading(false);
      })
      .catch(() => {
        setIsLoading(false);
      })
      .finally(() => {
        history.push("/");
      });
  };
  return <LoginPage handleSubmit={handleSubmit} isLoading={isLoading} />;
};

export default connect(null, {
  loginAsync,
})(LoginContainer);
