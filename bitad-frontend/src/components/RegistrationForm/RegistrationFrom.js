import styles from "./RegistrationFrom.module.css";
import { Link, useHistory } from "react-router-dom";
import { CheckboxField } from "./CheckboxField";
import { FieldWrapper } from "./FieldWrapper";
import { useForm } from "react-hook-form";
import { Input } from "./Input";
import { InputEmail } from "./InputEmail";
import { FieldInput } from "./FieldInput";
import api from "../../api/api";
import { useState } from "react";
import { WorkshopSelect } from "./WorkshopSelect";
import SubmitButton from "./SubmitButton";

function RegistrationFrom() {
  const {
    register,
    handleSubmit,
    reset,
    getValues,
    formState: { errors },
  } = useForm();

  const [isSubmitting, setIsSubmitting] = useState(false);
  const [submitError, setSubmitError] = useState(false);
  const history = useHistory();

  const onSubmit = (data) => {
    const {
      email,
      password,
      workshopCode,
      firstName,
      lastName,
      acceptedRegulations,
      acceptedDataProcessing,
    } = data;
    setIsSubmitting(true);

    api
      .post("/User/RegisterUser", {
        email,
        password,
        firstName,
        lastName,
        workshopCode,
        acceptedRegulations,
        acceptedDataProcessing,
      })
      .then(() => {
        setSubmitError(false);
        history.push("/account-creation-info/success");
      })
      .catch((err) => {
        setSubmitError(true);
        setIsSubmitting(false);
        history.push("/account-creation-info/error");
        console.log(err);
      });

    if (isSubmitting === false && submitError === false) reset({});
  };

  return (
    <form className={styles.form} onSubmit={handleSubmit(onSubmit)} noValidate>
      <div className={styles.form__section}>
        <FieldWrapper>
          <FieldInput name="firstName" labelText="Imię*">
            <Input
              register={register}
              errors={errors}
              name="firstName"
              pattern={{
                value: /^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ-]+$/i,
                message: "Tylko litery",
              }}
              maxLength={{ value: 24, message: "Maksymalnie 24 znaki" }}
            />
          </FieldInput>
          <FieldInput name="lastName" labelText="Nazwisko*">
            <Input
              register={register}
              errors={errors}
              name="lastName"
              pattern={{
                value: /^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ-]+$/i,
                message: "Tylko litery",
              }}
            />
          </FieldInput>
        </FieldWrapper>
        <FieldInput name="email" labelText="Adres email*">
          <InputEmail register={register} errors={errors} name="email" />
        </FieldInput>
        <FieldInput
          name="password"
          labelText="Utwórz hasło do aplikacji QR Code*"
        >
          <Input
            register={register}
            errors={errors}
            name="password"
            type="password"
            minLength={{ value: 6, message: "Minimum 6 znaków" }}
          />
        </FieldInput>
        <FieldInput name="repeatedPassword" labelText="Powtórz hasło*">
          <Input
            name="repeatedPassword"
            register={register}
            type="password"
            minLength={{ value: 6, message: "Minimum 6 znaków" }}
            validate={{
              checkIfEquole: (value) =>
                value === getValues("password") || "Hasła nie są takie same",
            }}
            errors={errors}
          />
        </FieldInput>
        <FieldInput
          name="workshopCode"
          labelText="Opcjonalny zapis na warsztaty"
        >
          <WorkshopSelect
            name="workshopCode"
            register={register}
            errors={errors}
          />
        </FieldInput>
      </div>
      <div>
        <CheckboxField
          name="acceptedRegulations"
          register={register}
          text={
            <>
              Zapoznałem/am się z <Link to="/Regulamin.pdf">Regulaminem</Link>.*
            </>
          }
          errors={errors}
        />
        <CheckboxField
          name="acceptedDataProcessing"
          register={register}
          text="Wyrażam zgodę na przetwarzanie moich danych osobowych dla potrzeb niezbędnych do udziału w konferencji.*"
          errors={errors}
        />
      </div>
      <p>*pole wymagane</p>
      <SubmitButton>Zapisz się</SubmitButton>
    </form>
  );
}
export default RegistrationFrom;
