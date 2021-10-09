import ShortInfo from "../../components/ShortInfo/ShortInfo";
import { useParams, useHistory } from "react-router-dom";
import { FieldInput } from "../../components/RegistrationForm/FieldInput";
import { Input } from "../../components/RegistrationForm/Input";
import { useForm } from "react-hook-form";
import SubmitButton from "../../components/RegistrationForm/SubmitButton";
import styles from "./AccountRestartPassword.module.css";
import api from "../../api/api";

function AccountRestartPassword({ title = "Podaj nowe hasło" }) {
  const { code } = useParams();
  const history = useHistory();
  const {
    register,
    handleSubmit,
    getValues,
    formState: { errors },
  } = useForm();

  const onSubmit = (data) => {
    console.log(data);
    api
      .patch(`/User/ResetPassword?code=${code}&password=${data.password}`)
      .then(() => {
        history.push("/account-reset-password-info/success");
      })
      .catch(() => {
        history.push("/account-reset-password-info/error");
      });
  };

  return (
    <ShortInfo title={title}>
      <form
        onSubmit={handleSubmit(onSubmit)}
        noValidate
        className={styles.form}
      >
        <FieldInput name="password" labelText="Nowe hasło">
          <Input
            register={register}
            errors={errors}
            name="password"
            type="password"
          />
        </FieldInput>
        <FieldInput name="repeatedPassword" labelText="Powtórz hasło*">
          <Input
            name="repeatedPassword"
            register={register}
            type="password"
            validate={{
              checkIfEquole: (value) =>
                value === getValues("password") || "Hasła nie są takie same",
            }}
            errors={errors}
          />
        </FieldInput>
        <SubmitButton>Zapisz hasło</SubmitButton>
      </form>
    </ShortInfo>
  );
}

export default AccountRestartPassword;
