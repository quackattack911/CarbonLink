using Newtonsoft.Json;

namespace CarbonLinkServer.Service.Tesla;

public class ChargeStateDto
{
    [JsonProperty("battery_heater_on")]
    public bool? BatteryHeaterOn { get; set; }

    [JsonProperty("battery_level")]
    public long? BatteryLevel { get; set; }

    [JsonProperty("battery_range")]
    public double? BatteryRange { get; set; }

    [JsonProperty("charge_amps")]
    public long? ChargeAmps { get; set; }

    [JsonProperty("charge_current_request")]
    public long? ChargeCurrentRequest { get; set; }

    [JsonProperty("charge_current_request_max")]
    public long? ChargeCurrentRequestMax { get; set; }

    [JsonProperty("charge_enable_request")]
    public bool? ChargeEnableRequest { get; set; }

    [JsonProperty("charge_energy_added")]
    public double? ChargeEnergyAdded { get; set; }

    [JsonProperty("charge_limit_soc")]
    public long? ChargeLimitSoc { get; set; }

    [JsonProperty("charge_limit_soc_min")]
    public long? ChargeLimitSocMin { get; set; }

    [JsonProperty("charge_limit_soc_max")]
    public long? ChargeLimitSocMax { get; set; }

    [JsonProperty("charge_limit_soc_std")]
    public long? ChargeLimitSocStd { get; set; }

    [JsonProperty("charge_miles_added_ideal")]
    public long? ChargeMilesAddedIdeal { get; set; }

    [JsonProperty("charge_miles_added_rated")]
    public double? ChargeMilesAddedRated { get; set; }

    [JsonProperty("charge_port_cold_weather_mode")]
    public bool? ChargePortColdWeatherMode { get; set; }

    [JsonProperty("charge_port_door_open")]
    public bool? ChargePortDoorOpen { get; set; }

    [JsonProperty("charge_port_latch")]
    public string? ChargePortLatch { get; set; }

    [JsonProperty("charge_rate")]
    public long? ChargeRate { get; set; }

    [JsonProperty("charge_to_max_range")]
    public bool? ChargeToMaxRange { get; set; }

    [JsonProperty("charger_actual_current")]
    public long? ChargerActualCurrent { get; set; }

    [JsonProperty("charger_phases")]
    public int? ChargerPhases { get; set; }

    [JsonProperty("charger_pilot_current")]
    public long? ChargerPilotCurrent { get; set; }

    [JsonProperty("charger_power")]
    public long? ChargerPower { get; set; }

    [JsonProperty("charger_voltage")]
    public long? ChargerVoltage { get; set; }

    [JsonProperty("charging_state")]
    public string? ChargingState { get; set; }

    [JsonProperty("conn_charge_cable")]
    public string? ConnChargeCable { get; set; }

    [JsonProperty("est_battery_range")]
    public double? EstBatteryRange { get; set; }

    [JsonProperty("fast_charger_brand")]
    public string? FastChargerBrand { get; set; }

    [JsonProperty("fast_charger_present")]
    public bool? FastChargerPresent { get; set; }

    [JsonProperty("fast_charger_type")]
    public string? FastChargerType { get; set; }

    [JsonProperty("ideal_battery_range")]
    public double? IdealBatteryRange { get; set; }

    [JsonProperty("managed_charging_active")]
    public bool? ManagedChargingActive { get; set; }

    [JsonProperty("managed_charging_start_time")]
    public long? ManagedChargingStartTime { get; set; }

    [JsonProperty("managed_charging_user_canceled")]
    public bool? ManagedChargingUserCanceled { get; set; }

    [JsonProperty("max_range_charge_counter")]
    public long? MaxRangeChargeCounter { get; set; }

    [JsonProperty("minutes_to_full_charge")]
    public long? MinutesToFullCharge { get; set; }

    [JsonProperty("not_enough_power_to_heat")]
    public bool? NotEnoughPowerToHeat { get; set; }

    [JsonProperty("off_peak_charging_enabled")]
    public bool? OffPeakChargingEnabled { get; set; }

    [JsonProperty("off_peak_charging_times")]
    public string? OffPeakChargingTimes { get; set; }

    [JsonProperty("off_peak_hours_end_time")]
    public long? OffPeakHoursEndTime { get; set; }

    [JsonProperty("preconditioning_enabled")]
    public bool? PreconditioningEnabled { get; set; }

    [JsonProperty("preconditioning_times")]
    public string? PreconditioningTimes { get; set; }

    [JsonProperty("scheduled_charging_mode")]
    public string? ScheduledChargingMode { get; set; }

    [JsonProperty("scheduled_charging_pending")]
    public bool? ScheduledChargingPending { get; set; }

    [JsonProperty("scheduled_charging_start_time")]
    public long? ScheduledChargingStartTime { get; set; }

    [JsonProperty("scheduled_departure_time")]
    public long? ScheduledDepartureTime { get; set; }

    [JsonProperty("time_to_full_charge")]
    public long? TimeToFullCharge { get; set; }

    [JsonProperty("timestamp")]
    public long? TimeStamp { get; set; }

    [JsonProperty("trip_charging")]
    public bool? TripCharging { get; set; }

    [JsonProperty("usable_battery_level")]
    public long? UsableBatteryLevel { get; set; }

    [JsonProperty("user_charge_enable_request")]
    public bool? UserChargeEnableRequest { get; set; }
}