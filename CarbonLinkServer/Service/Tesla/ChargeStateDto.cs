using Newtonsoft.Json;

namespace CarbonLinkServer.Service.Tesla;

public class ChargeStateDto
{
    public ChargeStateDto(
        string chargingState = null,
        string fastChargerType = null,
        string fastChargerBrand = null,
        long? chargeLimitSoc = null,
        long? chargeLimitSocStd = null,
        long? chargeLimitSocMin = null,
        long? chargeLimitSocMax = null,
        bool? chargeToMaxRange = null,
        long? maxRangeChargeCounter = null,
        bool? fastChargerPresent = null,
        double? batteryRange = null,
        double? estBatteryRange = null,
        double? idealBatteryRange = null,
        long? batteryLevel = null,
        long? usableBatteryLevel = null,
        double? chargeEnergyAdded = null,
        double? chargeMilesAddedRated = null,
        long? chargeMilesAddedIdeal = null,
        long? chargerVoltage = null,
        long? chargerPilotCurrent = null,
        long? chargerActualCurrent = null,
        long? chargerPower = null,
        long? timeToFullCharge = null,
        bool? tripCharging = null,
        long? chargeRate = null,
        bool? chargePortDoorOpen = null,
        string connChargeCable = null,
        long? scheduledChargingStartTime = null,
        bool? scheduledChargingPending = null,
        bool? userChargeEnableRequest = null,
        bool? chargeEnableRequest = null,
        int? chargerPhases = null,
        string chargePortLatch = null,
        long? chargeCurrentRequest = null,
        long? chargeCurrentRequestMax = null,
        bool? managedChargingActive = null,
        bool? managedChargingUserCanceled = null,
        long? managedChargingStartTime = null,
        bool? batteryHeaterOn = null,
        bool? notEnoughPowerToHeat = null,
        long timestamp = 0)
    {
        ChargingState = chargingState;
        FastChargerType = fastChargerType;
        FastChargerBrand = fastChargerBrand;
        ChargeLimitSoc = chargeLimitSoc;
        ChargeLimitSocStd = chargeLimitSocStd;
        ChargeLimitSocMin = chargeLimitSocMin;
        ChargeLimitSocMax = chargeLimitSocMax;
        ChargeToMaxRange = chargeToMaxRange;
        MaxRangeChargeCounter = maxRangeChargeCounter;
        FastChargerPresent = fastChargerPresent;
        BatteryRange = batteryRange;
        EstBatteryRange = estBatteryRange;
        IdealBatteryRange = idealBatteryRange;
        BatteryLevel = batteryLevel;
        UsableBatteryLevel = usableBatteryLevel;
        ChargeEnergyAdded = chargeEnergyAdded;
        ChargeMilesAddedRated = chargeMilesAddedRated;
        ChargeMilesAddedIdeal = chargeMilesAddedIdeal;
        ChargerVoltage = chargerVoltage;
        ChargerPilotCurrent = chargerPilotCurrent;
        ChargerActualCurrent = chargerActualCurrent;
        ChargerPower = chargerPower;
        TimeToFullCharge = timeToFullCharge;
        TripCharging = tripCharging;
        ChargeRate = chargeRate;
        ChargePortDoorOpen = chargePortDoorOpen;
        ConnChargeCable = connChargeCable;
        ScheduledChargingStartTime = scheduledChargingStartTime;
        ScheduledChargingPending = scheduledChargingPending;
        UserChargeEnableRequest = userChargeEnableRequest;
        ChargeEnableRequest = chargeEnableRequest;
        ChargerPhases = chargerPhases;
        ChargePortLatch = chargePortLatch;
        ChargeCurrentRequest = chargeCurrentRequest;
        ChargeCurrentRequestMax = chargeCurrentRequestMax;
        ManagedChargingActive = managedChargingActive;
        ManagedChargingUserCanceled = managedChargingUserCanceled;
        ManagedChargingStartTime = managedChargingStartTime;
        BatteryHeaterOn = batteryHeaterOn;
        NotEnoughPowerToHeat = notEnoughPowerToHeat;
        Timestamp = timestamp;
    }

    [JsonProperty("charging_state")]
    public string ChargingState { get; set; }

    [JsonProperty("fast_charger_type")]
    public string FasterChargerType { get; set; }

    [JsonProperty("fast_charger_brand")]
    public string FastChargerBrand { get; set; }

    [JsonProperty("charge_limit_soc")]
    public long? ChargeLimitSoc { get; set; }

    [JsonProperty("charge_limit_soc_std")]
    public long? ChargeLimitSocStd { get; set; }

    [JsonProperty("charge_limit_soc_min")]
    public long? ChargeLimitSocMin { get; set; }

    [JsonProperty("charge_limit_soc_max")]
    public long? ChargeLimitSocMax { get; set; }

    [JsonProperty("charge_to_max_range")]
    public bool? ChargeToMaxRange { get; set; }

    [JsonProperty("max_range_charge_counter")]
    public long? MaxRangeChargeCounter { get; set; }

    [JsonProperty("fast_charger_present")]
    public bool? FastChargerPresent { get; set; }

    [JsonProperty("battery_range")]
    public double? BatteryRange { get; set; }

    [JsonProperty("est_battery_range")]
    public double? EstBatteryRange { get; set; }

    [JsonProperty("ideal_battery_range")]
    public double? IdealBatteryRange { get; set; }

    [JsonProperty("battery_level")]
    public long? BatteryLevel { get; set; }

    [JsonProperty("usable_battery_level")]
    public long? UsableBatteryLevel { get; set; }

    [JsonProperty("charge_energy_added")]
    public double? ChargeEnergyAdded { get; set; }

    [JsonProperty("charge_miles_added_rated")]
    public double? ChargeMilesAddedRated { get; set; }

    [JsonProperty("charge_miles_added_ideal")]
    public long? ChargeMilesAddedIdeal { get; set; }

    [JsonProperty("charger_voltage")]
    public long? ChargerVoltage { get; set; }

    [JsonProperty("charger_pilot_current")]
    public long? ChargerPilotCurrent { get; set; }

    [JsonProperty("charger_actual_current")]
    public long? ChargerActualCurrent { get; set; }

    [JsonProperty("charger_power")]
    public long? ChargerPower { get; set; }

    [JsonProperty("time_to_full_charge")]
    public long? TimeToFullCharge { get; set; }

    [JsonProperty("trip_charging")]
    public bool? TripCharging { get; set; }

    [JsonProperty("charge_rate")]
    public long? ChargeRate { get; set; }

    [JsonProperty("charge_port_door_open")]
    public bool? ChargePortDoorOpen { get; set; }

    [JsonProperty("conn_charge_cable")]
    public string ConnChargeCable { get; set; }

    [JsonProperty("scheduled_charging_start_time")]
    public long? ScheduledChargingStartTime { get; set; }

    [JsonIgnore]
    public DateTime? ScheduledChargingStartTimeUtc { get; set; }

    [JsonProperty("scheduled_charging_pending")]
    public bool? ScheduledChargingPending { get; set; }

    [JsonProperty("user_charge_enable_request")]
    public bool? UserChargeEnableRequest { get; set; }

    [JsonProperty("charge_enable_request")]
    public bool? ChargeEnableRequest { get; set; }

    [JsonProperty("charger_phases")]
    public int? ChargerPhases { get; set; }

    [JsonProperty("charge_port_latch")]
    public string ChargePortLatch { get; set; }

    [JsonProperty("charge_current_request")]
    public long? ChargeCurrentRequest { get; set; }

    [JsonProperty("charge_current_request_max")]
    public long? ChargeCurrentRequestMax { get; set; }

    [JsonProperty("managed_charging_active")]
    public bool? ManagedChargingActive { get; set; }

    [JsonProperty("managed_charging_user_canceled")]
    public bool? ManagedChargingUserCanceled { get; set; }

    [JsonProperty("managed_charging_start_time")]
    public long? ManagedChargingStartTime { get; set; }

    [JsonIgnore]
    public DateTime? ManagedChargingStartTimeUtc { get; set; }

    [JsonProperty("battery_heater_on")]
    public bool? BatteryHeaterOn { get; set; }

    [JsonProperty("not_enough_power_to_heat")]
    public bool? NotEnoughPowerToHeat { get; set; }
}