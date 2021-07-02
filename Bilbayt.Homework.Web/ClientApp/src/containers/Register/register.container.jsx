import { useState } from "react";
import { connect } from "react-redux";
import RegisterPage from "../../pages/Register/register.page";
import { registerAsync } from "../../store/reducers/users/users.action";

const RegisterContainer = ({ registerAsync }) => {
  const [isLoading, setIsLoading] = useState(false);

  const handleSubmit = (data) => {
    setIsLoading(true);
    registerAsync(data).then(() => {
      setIsLoading(false);
    });
  };
  return <RegisterPage onSubmit={handleSubmit} isLoading={isLoading} />;
};

export default connect(null, {
  registerAsync,
})(RegisterContainer);
