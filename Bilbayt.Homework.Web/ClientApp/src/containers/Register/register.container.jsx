import { useState } from "react";
import { connect } from "react-redux";
import { useHistory } from "react-router";

import RegisterPage from "../../pages/Register/register.page";
import { registerAsync } from "../../store/reducers/users/users.action";

const RegisterContainer = ({ registerAsync }) => {
  const [isLoading, setIsLoading] = useState(false);
  const history = useHistory();

  const handleSubmit = (data) => {
    setIsLoading(true);
    registerAsync(data)
      .then(() => {
        setIsLoading(false);
        history.push("/login");
      })
      .catch(() => {
        setIsLoading(false);
      });
  };
  return <RegisterPage handleSubmit={handleSubmit} isLoading={isLoading} />;
};

export default connect(null, {
  registerAsync,
})(RegisterContainer);
