import styles from "./RegistrationFrom.module.css";
import { Link } from "react-router-dom";
import typography from "../../assets/css/Typography.module.css";
import { CheckboxField } from "./CheckboxField";
import { FieldWrapper } from "./FieldWrapper";
import { useForm } from "react-hook-form";
import { Input } from "./Input";
import { InputEmail } from "./InputEmail";
import { FieldInput } from "./FieldInput";
import { Select } from "./Select";
import api from "../../api/api";
import { useState } from "react";

function RegistrationFrom() {
  const {
    register,
    handleSubmit,
    reset,
    getValues,
    formState: { errors },
  } = useForm();

  const [isSubmitting, setIsSubmitting] = useState(false);
  const [response, setResponse] = useState({});

  // TODO: 1) Add workshop select. 2) Proper indication of form submission. 3) Add Google Recaptcha

  const onSubmit = (data) => {
    const { email, firstName, lastName, password } = data;
    setIsSubmitting(true);
    api
      .post("/User/RegisterUser", {
        email,
        firstName,
        lastName,
        username: "test",
        password,
        workshopCode: "string",
      })
      .then((res) => {
        if (!Array.isArray(res.data)) return;
        setResponse(res.data);
        setIsSubmitting(false);
        console.log(response);
      })
      .catch((err) => {
        console.log(err);
      });
    reset({});
  };

  return (
    <form className={styles.form} onSubmit={handleSubmit(onSubmit)} noValidate>
      <div className={styles.form__section}>
        <FieldWrapper>
          <FieldInput name="firstName" labelText="Imię*">
            <Input register={register} errors={errors} name="firstName" />
          </FieldInput>
          <FieldInput name="lastName" labelText="Nazwisko*">
            <Input register={register} errors={errors} name="lastName" />
          </FieldInput>
        </FieldWrapper>
        <FieldInput name="email" labelText="Adres email">
          <InputEmail register={register} errors={errors} name="email" />
        </FieldInput>
        <FieldInput
          name="password"
          labelText={
            <>
              Hasło do <Link to="/">aplikacji QR Code</Link>*
            </>
          }
        >
          <Input register={register} errors={errors} name="password" />
        </FieldInput>
        <FieldInput name="repeatedPassword" labelText="Powtórz hasło">
          <Input
            name="repeatedPassword"
            register={register}
            validate={{
              checkIfEquole: (value) =>
                value === getValues("password") || "Hasła nie są takie same",
            }}
            errors={errors}
          />
        </FieldInput>
        <FieldInput name="shirtSize" labelText="Rozmiar koszulki">
          <Select
            name="shirtSize"
            register={register}
            errors={errors}
            options={[
              { value: "xl", label: "XL" },
              { value: "l", label: "L" },
              { value: "m", label: "M" },
            ]}
          />
        </FieldInput>
      </div>
      <div>
        <CheckboxField
          name="terms1"
          register={register}
          text={
            <>
              Zapoznałem/am się z <Link to="/">Polityką Prywatności</Link> oraz
              z <Link to="/">Regulaminem</Link>.*
            </>
          }
          errors={errors}
        />
        <CheckboxField
          name="terms2"
          register={register}
          text="Wyrażam zgodę na przetwarzanie moich danych osobowych dla potrzeb niezbędnych do udziału w konferencji.*"
          errors={errors}
        />
      </div>
      <button className={`${typography.button} ${styles.form__button}`}>
        Zapisz się
      </button>
    </form>
  );
}
export default RegistrationFrom;
