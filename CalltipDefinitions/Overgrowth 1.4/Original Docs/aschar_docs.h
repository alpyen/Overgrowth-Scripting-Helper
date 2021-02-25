//Mandatory functions in script
bool Init(string)
void SetParameters()
void NotifyItemDetach(int)
void HandleEditorAttachment(int, int, bool)
void Contact()
void Collided(float, float, float, float, float)
void MovementObjectDeleted(int id)
void ScriptSwap()
void HandleCollisionsBetweenTwoCharacters(MovementObject @other)
void HitByItem(string material, vec3 point, int id, int type)
void Update(int)
void ForceApplied(vec3 force)
float GetTempHealth()
int WasHit(string type, string attack_path, vec3 dir, vec3 pos, int attacker_id, float attack_damage_mult, float attack_knockback_mult)
void Reset()
void PostReset()
void AttachWeapon(int)
void SetEnabled(bool)
void ReceiveMessage(string)
void UpdatePaused()
int AboutToBeHitByItem(int id)
void HandleAnimationEvent(string,vec3)
void DisplayMatrixUpdate()
void FinalAnimationMatrixUpdate(int)
void FinalAttachedItemUpdate(int)
void LayerRemoved(int id)

//Optional functions in script
void PreDrawCamera(float curr_game_time)
void PreDrawFrame(float curr_game_time)
void PreDrawCameraNoCull(float curr_game_time)
void AttachMisc(int)
void WasBlocked()
void ResetWaypointTarget()
void Dispose()

//Interface
    void push_back(const T&in);
    uint size() const;
void StartStopwatch();
uint64 StopAndReportStopwatch();
void EnterTelemetryZone(const string& in name);
void LeaveTelemetryZone();
uint UINT32MAX;
float fpFromIEEE(uint);
uint fpToIEEE(float);
double fpFromIEEE(uint64);
uint64 fpToIEEE(double);
float min(float,float);
float max(float,float);
int min(int,int);
int max(int,int);
float mix(float a,float b,float amount);
float cos(float);
float sin(float);
float tan(float);
float acos(float);
float asin(float);
float atan(float);
float atan2(float,float);
float log(float);
float log10(float);
float pow(float val, float exponent);
float sqrt(float);
int rand();
float RangedRandomFloat(float min, float max);
float ceil(float);
float abs(float);
float floor(float);
class vec2 {
    float x;
    float y;
    void f();
    void f(const vec2 &in);
    void f(float, float);
    void f(float);
    vec2 &opAddAssign(const vec2 &in);
    vec2 &opSubAssign(const vec2 &in);
    vec2 &opMulAssign(float);
    vec2 &opDivAssign(float);
    bool opEquals(const vec2 &in) const;
    vec2 opAdd(const vec2 &in) const;
    vec2 opSub(const vec2 &in) const;
    vec2 opMul(float) const;
    vec2 opMul_r(float) const;
    vec2 opDiv(float) const;
};
float length(const vec2 &in);
float length_squared(const vec2 &in);
float dot(const vec2 &in, const vec2 &in);
float distance(const vec2 &in, const vec2 &in);
float distance_squared(const vec2 &in, const vec2 &in);
vec2 normalize(const vec2 &in);
vec2 reflect(const vec2 &in vec, const vec2 &in normal);
vec2 mix(vec2 a,vec2 b,float alpha);
class vec3 {
    float x;
    float y;
    float z;
    void f();
    void f(const vec3 &in);
    void f(float, float, float);
    void f(float);
    vec3 &opAddAssign(const vec3 &in);
    vec3 &opSubAssign(const vec3 &in);
    vec3 &opMulAssign(float);
    vec3 &opDivAssign(float);
    bool opEquals(const vec3 &in) const;
    vec3 opAdd(const vec3 &in) const;
    vec3 opSub(const vec3 &in) const;
    vec3 opMul(float) const;
    vec3 opMul(const vec3& in) const;
    vec3 opMul_r(float) const;
    vec3 opDiv(float) const;
    float &opIndex(int);
};
float length(const vec3 &in);
float length_squared(const vec3 &in);
float dot(const vec3 &in, const vec3 &in);
float distance(const vec3 &in, const vec3 &in);
float distance_squared(const vec3 &in, const vec3 &in);
float xz_distance(const vec3 &in, const vec3 &in);
float xz_distance_squared(const vec3 &in, const vec3 &in);
vec3 normalize(const vec3 &in);
vec3 cross(const vec3 &in, const vec3 &in);
vec3 reflect(const vec3 &in vec, const vec3 &in normal);
vec3 mix(vec3 a,vec3 b,float alpha);
class vec4 {
    float x;
    float y;
    float z;
    float a;
    void f();
    void f(const vec4 &in);
    void f(float, float, float, float);
    void f(const vec3 &in, float);
    void f(float);
vec4 mix(vec4 a,vec4 b,float alpha);
};
class ivec2 {
    int x;
    int y;
    void f();
    void f(const ivec2 &in);
    void f(int, int);
    void f(int);
    ivec2 &opAddAssign(const ivec2 &in);
    ivec2 &opSubAssign(const ivec2 &in);
    ivec2 &opMulAssign(int);
    ivec2 &opDivAssign(int);
    ivec2 opAdd(const ivec2 &in) const;
    ivec2 opSub(const ivec2 &in) const;
    ivec2 opMul(int) const;
    ivec2 opDiv(int) const;
};
class ivec3 {
    int x;
    int y;
    void f();
    void f(const ivec3 &in);
    void f(int, int, int);
    void f(int);
};
class ivec4 {
    int x;
    int y;
    void f();
    void f(const ivec4 &in);
    void f(int, int, int, int);
    void f(int);
};
class quaternion {
    float x;
    float y;
    float z;
    float w;
    void f();
    void f(const quaternion &in);
    void f(float, float, float, float);
    void f(vec4); // Axis-angle (axis.x, axis.y, axis.z, angle_radians)
    void f();
    quaternion &opAssign(const quaternion &in);
    quaternion &opAddAssign(const quaternion &in);
    bool opEquals(const quaternion &in) const;
    quaternion opAdd(const quaternion &in) const;
    quaternion opMul(const quaternion &in) const;
    vec3 opMul(const vec3 &in) const;
};
vec3 Mult(quaternion, vec3); // Applies a quaternion rotation to a vector
quaternion mix(const quaternion &in a, const quaternion &in b, float alpha);
quaternion invert(quaternion quat);
void GetRotationBetweenVectors(const vec3 &in start, const vec3 &in end, quaternion &out rotation);
class mat4 {
    void f();
    void f(const mat4 &in);
    float &opIndex(uint);
    const float &opIndex(uint) const;
    mat4 opMul(mat4) const;
    vec3 opMul(vec3) const;
    vec3 opMul(vec4) const;
    void SetTranslationPart(vec3);
    vec3 GetTranslationPart() const;
    void SetRotationPart(mat4);
    mat4 GetRotationPart() const;
    void SetRotationX(float);
    void SetRotationY(float);
    void SetRotationZ(float);
    void SetColumn(int, vec3);
    vec3 GetColumn(int);
};
mat4 transpose(mat4);
mat4 invert(mat4);
mat4 mix(const mat4 &in a, const mat4 &in b, float alpha);
class mat3 {
    void f();
    void f(const mat3 &in);
    float &opIndex(uint);
    const float &opIndex(uint) const;
    vec3 opMul(const vec3 &in) const;
};
class BoneTransform { // An efficient way to define an unscaled transformation
    quaternion rotation;
    vec3 origin;
    void f();
    void f(const mat4 &in);
    void f(const BoneTransform &in);
    bool opEquals(const BoneTransform &in) const;
    BoneTransform opMul(const BoneTransform &in) const;
    BoneTransform opMul(const BoneTransform &in) const;
    vec3 opMul(const vec3 &in) const;
    mat4 GetMat4() const;
};
BoneTransform invert(const BoneTransform &in);
BoneTransform mix(const BoneTransform &in a, const BoneTransform &in b, float alpha);
mat4 Mat4FromQuaternion(const quaternion &in);
mat3 Mat3FromQuaternion(const quaternion &in);
quaternion QuaternionFromMat4(const mat4 &in);
    string &opAssign(vec3); // These 4 functions allow us to append vec3s to strings
    string &opAddAssign(vec3);
    string opAdd(vec3) const;
    string opAdd_r(vec3) const;
float time_step; // Time in seconds between engine time steps
float the_time; // The current time in seconds since engine started (in-game time)
float ui_time; // The current time in seconds since engine started (absolute time)
void TimedSlowMotion(float target_time_scale, float how_long, float delay); // Used to trigger brief periods of slow motion
uint64 GetPerformanceCounter(); // Get high precision time info for profiling
uint64 GetPerformanceFrequency(); // Used to convert PerformanceCounter into seconds
bool GetMenuPaused(); // Is game paused by a menu
void UpdateListener(vec3 pos, vec3 vel, vec3 facing, vec3 up);
int PlaySound(string path);
int PlaySoundLoop(const string &in path, float gain);
int PlaySoundLoopAtLocation(const string &in path, vec3 pos, float gain);
void SetSoundGain(int handle, float gain);
void SetSoundPitch(int handle, float pitch);
void SetSoundPosition(int handle, vec3 pos);
void StopSound(int handle);
int PlaySound(string path, vec3 position);
int PlaySoundGroup(string path);
int PlaySoundGroup(string path, float gain);
int PlaySoundGroup(string path, vec3 position);
int PlaySoundGroup(string path, vec3 position, float gain);
int PlaySoundGroup(string path, vec3 position, int priority);
void SetAirWhoosh(float volume, float pitch);
const int _sound_priority_max;
const int _sound_priority_very_high;
const int _sound_priority_high;
const int _sound_priority_med;
const int _sound_priority_low;
bool AddMusic(const string& in);
bool RemoveMusic(const string& in);
void PlaySong(const string& in);
void SetSong(const string& in);
string GetSong();
void SetSegment(const string& in);
void QueueSegment(const string& in);
void PlaySegment(const string& in);
string GetSegment();
array<string>@ GetLayerNames();
void SetLayerGain(const string &in layer, float gain);
float GetLayerGain(const string &in layer);
void ReloadMods();
void ConnectParticles(uint32 id_a, uint32 id_b); // Used for ribbon particles, like throat-cut blood
uint32 MakeParticle(string path, vec3 pos, vec3 vel);
uint32 MakeParticle(string path, vec3 pos, vec3 vel, vec3 color);
void TintParticle(uint32 id, const vec3 &in color);
void SetSunPosition(vec3);
void SetSunColor(vec3);
void SetSunAmbient(float);
vec3 GetSunPosition();
vec3 GetSunColor();
float GetSunAmbient();
void SetFlareDiffuse(float);
void SetSkyTint(vec3);
vec3 GetSkyTint();
vec3 GetBaseSkyTint();
void SetHDRWhitePoint(float);
void SetHDRBlackPoint(float);
void SetHDRBloomMult(float);
float GetHDRWhitePoint(void);
float GetHDRBlackPoint(void);
float GetHDRBloomMult(void);
const int _delete_on_update;
const int _fade;
const int _delete_on_draw;
const int _persistent;
int DebugDrawLine(vec3 start, vec3 end, vec3 color, int lifespan);
int DebugDrawBillboard(const string &in path, vec3 center, float scale, vec4 color, int lifespan);
int DebugDrawLine(vec3 start, vec3 end, vec3 start_color, vec3 end_color, int lifespan);
int DebugDrawLine(vec3 start, vec3 end, vec4 start_color, vec4 end_color, int lifespan);
int DebugDrawRibbon(vec3 start, vec3 end, vec4 start_color, vec4 end_color, float start_width, float end_width, int lifespan);
int DebugDrawRibbon(int lifespan);
void AddDebugDrawRibbonPoint(int which, vec3 pos, vec4 color, float width);
int DebugDrawLines(const array<vec3> &vertices, vec4 color, int lifespan);
int DebugDrawText(vec3 pos, string text, float scale, bool screen_space, int lifespan);
int DebugSetPosition(int id, vec3 pos);
int DebugDrawWireSphere(vec3 pos, float radius, vec3 color, int lifespan);
int DebugDrawWireMesh(string path, mat4 transform, vec4 color, int lifespan);
int DebugDrawWireScaledSphere(vec3 pos, float radius, vec3 scale, vec3 color, int lifespan);
int DebugDrawWireScaledSphere(vec3 pos, float radius, vec3 scale, vec4 color, int lifespan);
int DebugDrawWireCylinder(vec3 pos, float radius, float height, vec3 color, int lifespan);
int DebugDrawWireBox(vec3 pos, vec3 dimensions, vec3 color, int lifespan);
int DebugDrawCircle(mat4 transform, vec4 color, int lifespan);
void DebugDrawRemove(int id);
void DebugText(string key, string display_text, float lifetime);
string FloatString(float val, int digits);
int DebugDrawPoint(vec3 pos, vec4 color, int lifespan);
void ClearTemporaryDecals(); // Like blood splats and footprints
void DisplayError(const string &in title, const string &in contents);
enum LogType {
    fatal = 32,
    error = 16,
    warning = 8,
    info = 4,
    debug = 2,
    spam = 1,
void Log( LogType level, const string &in str );
string GetBuildVersionShort( );
string GetBuildVersionFull( );
string GetBuildTimestamp( );
enum JsonValueType {
    JSONnullValue = 0,
    JSONintValue = 1,
    JSONuintValue = 2,
    JSONrealValue = 3,
    JSONstringValue = 4,
    JSONbooleanValue = 5,
    JSONarrayValue = 6,
    JSONobjectValue = 7,
class JSONValue {
    void JSONValue();
    void JSONValue( JsonValueType &in );
    void JSONValue( int &in );
    void JSONValue( uint &in);
    void JSONValue( int64 &in);
    void JSONValue( uint64 &in );
    void JSONValue( double &in );
    void JSONValue( string &in );
    void JSONValue( bool &in );
    void JSONValue( JSONValue &in );
    void JSONValue();
    JSONValue& opAssign(const JSONValue &in other);
    JSONValue& opIndex( const string &in );
    JSONValue& opIndex( const int &in );
    string asString();
    JsonValueType type();
    string typeName();
    int asInt();
    uint asUInt();
    int64 asInt64();
    uint64 asUInt64();
    float asFloat();
    double asDouble();
    bool asBool();
    bool isNull();
    bool isBool();
    bool isInt();
    bool isInt64();
    bool isUInt();
    bool isUInt64();
    bool isIntegral();
    bool isDouble();
    bool isNumeric();
    bool isString();
    bool isArray();
    bool isObject();
    bool isConvertibleTo(JsonValueType type);
    uint size();
    bool empty();
    void clear();
    void resize(uint64);
    bool isValidIndex(uint64);
    JSONValue& append(const JSONValue &in);
    bool removeMember( const string &in );
    bool removeIndex( uint  i );
    bool isMember(const string &in);
    array<string>@ getMemberNames();
class JSON {
    void JSON();
    void JSON();
    JSON& opAssign(const JSON &in other);
    bool parseString(string &in);
    bool parseFile(string &in);
    string writeString(bool=false);
    JSONValue& getRoot();
string GetConfigValueString(string index);
array<string>@ GetConfigValueOptions(string index);
float GetConfigValueFloat(string index);
void SetConfigValueFloat(string key, float value);
bool GetConfigValueBool(string index);
void SetConfigValueString(string key, string value);
void SetConfigValueBool(string key, bool value);
void SetConfigValueInt(string key, int value);
int GetConfigValueInt(string key);
int GetMonitorCount();
array<vec2>@ GetPossibleResolutions();
void ReloadStaticValues();
array<string>@ GetAvailableBindingCategories();
array<string>@ GetAvailableBindings(const string& in);
string GetBindingValue(string binding_category, string binding);
void SetBindingValue(string binding_category, string binding, string value);
void SetKeyboardBindingValue(string binding_category, string binding, uint32 scancode);
void SetMouseBindingValue(string binding_category, string binding, uint32 button);
void SetMouseBindingValue(string binding_category, string binding, string text);
void SetControllerBindingValue(string binding_category, string binding, uint32 input);
void SaveConfig();
bool ConfigHasKey(string key);
void ResetBinding(string binding_category, string binding);
string ToUpper(string &in);
uint GetLengthInBytesForNCodepoints( const string& in, uint codepoint_index );
uint GetCodepointCount( const string& in );
bool DirectoryExists(string& in);
bool FileExists(string& in);
class LevelDetails {
    void f();
    string GetName();
};
enum UserVote {
    k_VoteUnknown = 0,
    k_VoteNone = 1,
    k_VoteUp = 2,
    k_VoteDown = 3,
class Parameter {
    void f();
    void f(const Parameter &in other);
    void f();
    Parameter& opAssign(const Parameter &in other);
    Parameter opIndex( const string &in );
    Parameter opIndex( const int &in );
    string getName();
    bool isEmpty();
    bool isString();
    bool isArray();
    bool isTable();
    uint size();
    string asString();
    bool contains(const string &in value);
    bool containsName(const string &in value);
class ModID {
    void f();
    void f();
    bool Valid();
};
class MenuItem {
    void f();
    void f();
    string GetTitle();
    string GetCategory();
    string GetPath();
    string GetThumbnail();
};
class SpawnerItem {
    void SpawnerItem();
    void SpawnerItem();
    string GetTitle();
    string GetCategory();
    string GetPath();
    string GetThumbnail();
};
class ModLevel {
    void f();
    void f(const ModLevel &in other);
    void f();
    ModLevel& opAssign(const ModLevel &in other);
    string GetTitle();
    string GetID();
    string GetThumbnail();
    string GetPath();
    LevelDetails GetDetails();
    bool CompletionOptional();
    Parameter GetParameter();
};
class Campaign {
    void f();
    void f(const Campaign &in other);
    void f();
    Campaign& opAssign(const Campaign &in other);
    string GetID();
    string GetTitle();
    string GetThumbnail();
    string GetMainScript();
    string GetMenuScript();
    string GetAttribute(string &in id);
    array<ModLevel>@ GetLevels();
    ModLevel GetLevel(string &in id);
    Parameter GetParameter();
Campaign GetCampaign(string& campaign_id);
array<Campaign>@ GetCampaigns();
bool ModIsActive(ModID& id);
bool ModNeedsRestart(ModID& id);
bool ModIsValid(ModID& id);
bool ModIsCore(ModID& id);
bool ModCanActivate(ModID& id);
int ModGetSource(ModID& id);
string ModGetID(ModID& id);
string ModGetName(ModID& id);
string ModGetAuthor(ModID& id);
string ModGetVersion(ModID& id);
string ModGetTags(ModID& id);
string ModGetPath(ModID& sid);
string ModGetValidityString(ModID& sid);
string ModGetDescription(ModID& id);
string ModGetThumbnail(ModID& sid);
array<MenuItem>@ ModGetMenuItems(ModID& sid);
array<SpawnerItem>@ ModGetSpawnerItems(ModID& sid);
array<SpawnerItem>@ ModGetAllSpawnerItems(bool only_include_active = true);
array<ModLevel>@ ModGetCampaignLevels(ModID& sid);
array<ModLevel>@ ModGetSingleLevels(ModID& sid);
UserVote ModGetUserVote(ModID& sid);
void RequestModSetUserVote(ModID& id, bool voteup);
void RequestModSetFavorite(ModID& id, bool fav);
bool ModIsFavorite(ModID& id);
array<ModID>@ GetModSids();
array<ModID>@ GetActiveModSids();
bool ModActivation(ModID& sid, bool active);
void RequestWorkshopSubscribe(ModID& id);
void RequestWorkshopUnSubscribe(ModID& id);
bool IsWorkshopSubscribed(ModID& id);
bool IsWorkshopMod(ModID& id);
bool IsWorkshopAvailable();
void SaveModConfig();
void OpenModWorkshopPage(ModID& id);
void OpenModAuthorWorkshopPage(ModID& id);
void OpenWorkshop();
void DeactivateAllMods();
uint WorkshopSubscribedNotInstalledCount();
uint WorkshopDownloadingCount();
uint WorkshopDownloadPendingCount();
uint WorkshopNeedsUpdateCount();
float WorkshopTotalDownloadProgress();
void StorageSetString(string index, string value);
bool StorageHasString(string index);
string StorageGetString(string index);
void StorageSetInt32(string index, int value);
bool StorageHasInt32(string index);
int StorageGetInt32(string index);
void PrintCallstack();
class ASContext {
    void PrintGlobalVars();
};
ASContext context;
bool GetInputDown(int controller_id, const string &in input_label);
bool GetInputDownFiltered(int controller_id, const string &in input_label, uint filter);
bool GetInputPressed(int controller_id, const string &in input_label);
bool GetInputPressedFiltered(int controller_id, const string &in input_label, uint filter);
void ActivateKeyboardEvents();
void DeactivateKeyboardEvents();
void StartTextInput();
void StopTextInput();
float GetLookXAxis(int controller_id);
float GetLookYAxis(int controller_id);
float GetMoveXAxis(int controller_id);
float GetMoveYAxis(int controller_id);
void SetGrabMouse(bool);
bool DebugKeysEnabled();
bool EditorEnabled();
void LoadEditorLevel();
bool IsKeyDown(int key_code);
int GetCodeForKey(string key_name);
string GetStringDescriptionForBinding( const string& in, const string& in );
string GetLocaleStringForScancode(int scancode);
string GetStringForMouseButton(int button);
string GetStringForControllerInput(int input);
string GetStringForMouseString(const string& text);
enum KeyboardInputModeFlag {
    KIMF_NO = 0,
    KIMF_MENU = 1,
    KIMF_PLAYING = 2,
    KIMF_LEVEL_EDITOR_GENERAL = 4,
    KIMF_LEVEL_EDITOR_DIALOGUE_EDITOR = 8,
    KIMF_GUI_GENERAL = 16,
    KIMF_ANY = 268435455,
enum SDLNumeric {
    K_ESCAPE = 27,
    K_ENTER = 13,
    KP_ENTER = 1073741912,
    K_BACKSPACE = 8,
    K_TAB = 9,
    K_0 = 48,
    K_1 = 49,
    K_2 = 50,
    K_3 = 51,
    K_4 = 52,
    K_5 = 53,
    K_6 = 54,
    K_7 = 55,
    K_8 = 56,
    K_9 = 57,
    KP_0 = 1073741922,
    KP_1 = 1073741913,
    KP_2 = 1073741914,
    KP_3 = 1073741915,
    KP_4 = 1073741916,
    KP_5 = 1073741917,
    KP_6 = 1073741918,
    KP_7 = 1073741919,
    KP_8 = 1073741920,
    KP_9 = 1073741921,
uint GetInputMode();
class KeyboardPress {
    uint16 s_id;
    uint32 keycode;
    uint32 scancode;
    uint16 mod;
float last_keyboard_event_time;
float last_mouse_event_time;
float last_controller_event_time;
array<KeyboardPress>@ GetRawKeyboardInputs();
enum MouseButton {
    LEFT = 0,
    MIDDLE = 1,
    RIGHT = 2,
    FOURTH = 3,
    FIFTH = 4,
    SIXTH = 5,
    SEVENTH = 6,
    EIGHT = 7,
    NINTH = 8,
    TENTH = 9,
    TWELFTH = 10,
class MousePress {
    uint16 s_id;
    MouseButton button;
array<MousePress>@ GetRawMouseInputs();
enum ControllerInput {
    A = 0,
    B = 1,
    X = 2,
    Y = 3,
    D_UP = 4,
    D_RIGHT = 5,
    D_DOWN = 6,
    D_LEFT = 7,
    START = 8,
    BACK = 9,
    GUIDE = 10,
    L_STICK_PRESSED = 11,
    R_STICK_PRESSED = 12,
    LB = 13,
    RB = 14,
    L_STICK_XN = 22,
    L_STICK_XP = 23,
    L_STICK_YN = 24,
    L_STICK_YP = 25,
    R_STICK_XN = 26,
    R_STICK_XP = 27,
    R_STICK_YN = 28,
    R_STICK_YP = 29,
    L_TRIGGER = 19,
    R_TRIGGER = 20,
class ControllerPress {
    uint32 s_id;
    ControllerInput input;
    float depth;
array<ControllerPress>@ GetRawControllerInputs(int which);
bool IsControllerConnected();
class Camera {
    vec3 &GetTint();
    void SetTint(const vec3 &in);
    vec3 &GetVignetteTint();
    void SetVignetteTint(const vec3 &in);
    void FixDiscontinuity();
    vec3 GetFacing();
    vec3 GetFlatFacing();
    vec3 GetMouseRay(); // Direction that mouse cursor is pointing
    float GetXRotation();
    void SetXRotation(float);
    float GetYRotation();
    void SetYRotation(float);
    float GetZRotation();
    void SetZRotation(float);
    vec3 GetPos();
    vec3 GetUpVector();
    void SetPos(vec3);
    void SetFacing(vec3);
    void SetUp(vec3);
    void CalcFacing();
    void SetVelocity(vec3);
    void LookAt(vec3 target);
    void SetFOV(float);
    float GetFOV();
    bool GetAutoCamera();
    void SetDistance(float); // From orbit point, for chase camera
    void SetInterpSteps(int); // Number of time steps between camera updates
    int GetFlags();
    void SetFlags(int);
    void CalcUp();
    void SetDOF(float near_blur, float near_dist, float near_transition, float far_blur, float far_dist, float far_transition);
};
Camera camera;
bool GetSplitscreen();
int GetBloodLevel();
const vec3 &GetBloodTint();
enum CameraFlags {
    kEditorCamera = 1,
    kPreviewCamera = 2,
};
int GetScreenWidth();
int GetScreenHeight();
class Physics {
    vec3 gravity_vector;
};
Physics physics;
class TextStyle {
    int font_face_id;
    void f();
    void f();
    void SetAlignment(int i);
};
class TextMetrics {
    int advance_x;
    int advance_y;
    int bounds_x;
    int bounds_y;
    float ascenderRatio;
};
class TextCanvasTexture {
    void Create(int width, int height);
    void ClearTextCanvas();
    void UploadTextCanvasToTexture();
    void DebugDrawBillboard(const vec3 &in pos, float scale, int lifespan);
    void AddText(const string &in, const TextStyle &in, uint char_limit);
    void AddTextMultiline(const string &in, const TextStyle &in, uint char_limit);
    void GetTextMetrics(const string &in, const TextStyle &in, TextMetrics &out, uint char_limit);
    void SetPenPosition(const vec2 &in);
    void SetPenColor(int r, int g, int b, int a);
    void SetPenRotation(float rotation);
};
enum TextAtlasFlags {
    kSmallLowercase = 1,
};
int GetFontFaceID(const string &in path, int pixel_height);
void DisposeTextAtlases();
void DrawTextAtlas(const string &in path, int pixel_height, int flags, const string &in txt, int x, int y, vec4 color);
void DrawTextAtlas2(const string &in path, int pixel_height, int flags, const string &in txt, int x, int y, vec4 color, uint char_limit);
TextMetrics GetTextAtlasMetrics(const string &in path, int pixel_height, int flags, const string &in txt );
TextMetrics GetTextAtlasMetrics2(const string &in path, int pixel_height, int flags, const string &in txt, uint char_limit );
class ScriptParams {
    const string &GetString (const string &in key);
    float GetFloat (const string &in key);
    int GetInt (const string &in key);
    float SetFloat (const string &in key, float val);
    int SetInt (const string &in key, int);
    void SetString (const string &in key, const string &in val);
    void AddInt (const string &in key, int default_val);
    void AddIntSlider (const string &in key, int default_val, const string &in bounds);
    void AddFloatSlider (const string &in key, float default_val, const string &in bounds);
    void AddIntCheckbox (const string &in key, bool default_val);
    void AddFloat (const string &in key, float default_val);
    void AddString (const string &in key, const string &in default_val);
    void ASAddJSONFromString (const string &in key, const string &in default_val);
    void AddJSON (const string &in key, JSON &in default_val);
    JSON GetJSON (const string &in key);
    void Remove (const string &in key);
    bool HasParam (const string &in key);
    bool IsParamInt(const string &in key);
    bool IsParamFloat(const string &in key);
    bool IsParamString(const string &in key);
    bool IsParamJSON(const string &in key);
};
class Level {
    bool HasFunction(const string &in function_definition);
    int QueryIntFunction(const string &in function);
    int GetNumObjectives();
    int GetNumAchievements();
    string GetObjective(int which);
    string GetAchievement(int which);
    void SendMessage(const string& in message);
    void Execute(string code);
    const string& GetPath(const string& in key); // Get path from paths xml file
    bool HasFocus();
    bool DialogueCameraControl();
    bool LevelBoundaries();
    int CreateTextElement();
    void DeleteTextElement(int which);
    TextCanvasTexture@ GetTextElement(int which);
    void GetCollidingObjects(int id, array<int> @array);
    void ReceiveLevelEvents(int id);
    void StopReceivingLevelEvents(int id);
    bool HasVar(const string &in name);
    int GetIntVar(const string &in name);
    int GetArrayIntVar(const string &in name, int index);
    float GetFloatVar(const string &in name);
    bool GetBoolVar(const string &in name);
    bool WaitingForInput();
    ScriptParams@ GetScriptParams();
};
Level level;
bool CheckSaveLevelChanges();
void ClearUndoHistory();
void RibbonItemSetEnabled(const string &in, bool);
void RibbonItemSetToggled(const string &in, bool);
void RibbonItemFlash(const string &in);
bool MediaMode();
void SetMediaMode(bool);
void SetInterlevelData(const string &in, const string &in);
string GetInterlevelData(const string &in);
enum SamplePolyFlag {
    POLYFLAGS_NONE = 0,
    POLYFLAGS_WALK = 1,
    POLYFLAGS_SWIM = 2,
    POLYFLAGS_DOOR = 4,
    POLYFLAGS_JUMP1 = 8,
    POLYFLAGS_JUMP2 = 16,
    POLYFLAGS_JUMP3 = 32,
    POLYFLAGS_JUMP4 = 64,
    POLYFLAGS_JUMP5 = 128,
    POLYFLAGS_JUMP_ALL = 248,
    POLYFLAGS_DISABLED = 256,
    POLYFLAGS_ALL = 255,
enum NavPathFlag {
    DT_STRAIGHTPATH_START = 1,
    DT_STRAIGHTPATH_END = 2,
    DT_STRAIGHTPATH_OFFMESH_CONNECTION = 4,
class NavPath {
    void NavPath();
    void NavPath(const NavPath &in other);
    void NavPath();
    NavPath& opAssign(const NavPath &in other);
    bool success;
    int NumPoints();
    vec3 GetPoint(int);
    uint8 GetFlag(int);
};
class NavPoint {
    void NavPoint();
    void NavPoint(const NavPoint &in other);
    void NavPoint();
    NavPoint& opAssign(const NavPoint &in other);
    bool IsSuccess();
    vec3 GetPoint();
};
NavPath GetPath(vec3 start, vec3 end);
NavPath GetPath(vec3 start, vec3 end, uint16 include_poly_flags, uint16 exclude_poly_flags);
vec3 NavRaycast(vec3 start, vec3 end);
vec3 NavRaycastSlide(vec3 start, vec3 end, int depth);
NavPoint GetNavPoint(vec3);
vec3 GetNavPointPos(vec3);
void SendMessage(int target, int type, vec3 vec_a, vec3 vec_b);
void SendMessage(int type, string msg);
void SendGlobalMessage(string msg);
int _plant_movement_msg;
int _editor_msg;
class TokenIterator {
    void Init();
    bool FindNextToken(const string& in);
    string GetToken(const string& in);
};
void Breakpoint(int);
class AttackScriptGetter { // Used to query information from an attack xml file
    AttackScriptGetter@ f();
    void AttackScriptGetter();
    void AttackScriptGetter();
    void Load(const string &in path); // Load an attack xml file into the attack script getter (e.g. "Data/Attacks/knifeslash.xml")
    string GetPath();
    string GetSpecial();
    string GetUnblockedAnimPath();
    string GetBlockedAnimPath();
    string GetThrowAnimPath();
    string GetThrownAnimPath();
    string GetThrownCounterAnimPath();
    int IsThrow();
    int GetHeight();
    vec3 GetCutPlane();
    int GetCutPlaneType();
    bool HasCutPlane();
    vec3 GetStabDir();
    int GetStabDirType();
    bool HasStabDir();
    int GetDirection();
    int GetSwapStance();
    int GetSwapStanceBlocked();
    int GetUnblockable();
    int GetFleshUnblockable();
    int GetAsLayer();
    string GetAlternate();
    string GetReactionPath();
    string GetMaterialEvent();
    vec3 GetImpactDir();
    float GetBlockDamage();
    float GetSharpDamage();
    float GetDamage();
    float GetForce();
    int GetMirrored();
    int GetMobile();
};
const int _high;
const int _medium;
const int _low;
const int _right;
const int _front;
const int _left;
ScriptParams params;
float atof(const string &in str);
int atoi(const string &in str);
enum CollisionSides {
    DOUBLE_SIDED = 1,
    SINGLE_SIDED = 0,
};
class CollisionPoint {
    vec3 position;
    vec3 normal;
    vec3 custom_normal;
    int id;
    int tri;
};
class SphereCollision {
    vec3 position;
    vec3 adjusted_position;
    float radius;
    int NumContacts();
    CollisionPoint GetContact(int);
};
class ASCollisions {
    vec3 GetSlidingCapsuleCollision(vec3 start, vec3 end, float radius);
    void GetSlidingSphereCollision(vec3 pos, float radius);
    void GetSlidingSphereCollisionDoubleSided(vec3 pos, float radius);
    void GetScaledSphereCollision(vec3 pos, float radius, vec3 scale);
    void GetScaledSpherePlantCollision(vec3 pos, float radius, vec3 scale);
    void GetSlidingScaledSphereCollision(vec3 pos, float radius, vec3 scale);
    void GetCylinderCollision(vec3 pos, float radius, float height);
    void GetCylinderCollisionDoubleSided(vec3 pos, float radius, float height);
    void GetSweptSphereCollision(const vec3 &in start, const vec3 &in end, float radius);
    void GetSweptSphereCollisionCharacters(vec3 start, vec3 end, float radius);
    void GetSweptCylinderCollision(vec3 start, vec3 end, float radius, float height);
    void GetSweptCylinderCollisionDoubleSided(vec3 start, vec3 end, float radius, float height);
    void GetSweptBoxCollision(vec3 start, vec3 end, vec3 dimensions);
    void CheckRayCollisionCharacters(vec3 start, vec3 end);
    vec3 GetRayCollision(vec3 start, vec3 end);
    void GetObjRayCollision(vec3 start, vec3 end);
    void GetPlantRayCollision(vec3 start, vec3 end);
    void GetObjectsInSphere(vec3 pos, float radius);
};
ASCollisions col; // Used to access collision functions
SphereCollision sphere_col; // Stores results of collision functions
vec3 LineLineIntersect(vec3 start_a, vec3 end_a, vec3 start_b, vec3 end_b); // Get closest point between two line segments
class AnimationClient {
    float GetAnimationEventTime(const string &in event);
    float GetTimeUntilEvent(const string &in event);
    void SetAnimationCallback(const string &in function);
    void AddAnimationOffset(const vec3 &in);
    void AddAnimationRotOffset(float radians);
    int AddLayer(const string &in anim_path, float transition_speed, int8 flags);
    int RemoveLayer(int id, float transition_speed);
    void SetBlendCoord(const string &in coord_label, float coord_value);
    void SetLayerOpacity(int id, float opacity);
    void SetSpeedMult(float);
    void SetAnimatedItemID(int index, int id);
    void SetLayerItemID(int layer, int index, int id);
    const string& GetCurrAnim();
    float GetNormalizedAnimTime();
    float GetAnimationSpeed();
    void RemoveAllLayers();
    void Reset();
};
class Skeleton {
    vec3 GetCenterOfMass();
    void SetBoneInflate(int bone_id, float amount);
    int GetParent(int bone_id);
    bool IKBoneExists(const string& in);
    float GetBoneMass(int bone_id);
    int IKBoneStart(const string& in IK_label);
    int IKBoneLength(const string& in IK_label);
    int NumBones();
    vec3 GetBoneLinearVelocity(int which);
    mat4 GetBoneTransform(int bone_id);
    void SetBoneTransform(int bone_id, const mat4 &in transform);
    vec3 GetPointPos(int bone_id);
    int GetBonePoint(int bone_id, int which_point);
    void AddVelocity(const vec3 &in vel);
    mat4 GetBindMatrix(int bone_id);
    bool HasPhysics(int bone_id);
    array<float> @GetConvexHullPoints(int bone_id);
    BoneTransform ApplyParentRotations(const array<BoneTransform> &in matrices, int id);
};
class RiggedObject {
    bool ik_enabled;
    int anim_update_period;
    int curr_anim_update_time;
    vec3 GetBonePosition(int bone);
    void AddWaterCube(const mat4 &in transform);
    void Ignite();
    void Extinguish();
    void SetFire(float fire);
    void SetWet(float wet);
    BoneTransform GetFrameMatrix(int which);
    void SetFrameMatrix(int which, const BoneTransform &in transform);
    float GetCharScale();
    float GetRelativeCharScale();
    void Draw();
    void CutPlane(const vec3 &in normal, const vec3 &in position, const vec3 &in direction, int type, int depth);
    void Stab(const vec3 &in position, const vec3 &in direction, int type, int depth);
    void SetRagdollStrength(float);
    void RefreshRagdoll();
    void SetRagdollDamping(float);
    void ApplyForceToRagdoll(const vec3 &in force, const vec3 &in position);
    void ApplyForceToBone(const vec3 &in force, const int &in bone);
    void ApplyForceLineToRagdoll(const vec3 &in force, const vec3 &in position, const vec3 &in line_direction);
    void MoveRagdollPart(const string &in, const vec3 &in, float);
    void FixedRagdollPart(int boneID, const vec3 &in);
    void SpikeRagdollPart(int boneID, const vec3 &start, const vec3 &end, const vec3 &pos);
    void ClearBoneConstraints();
    vec3 GetAvgPosition();
    vec3 GetAvgVelocity();
    void CleanBlood();
    void CreateBloodDrip(const string &in IK_label, int IK_link, const vec3 &in raycast_direction);
    void CreateBloodDripAtBone(int bone_id, int IK_link, const vec3 &in raycast_direction);
    vec3 GetAvgAngularVelocity();
    vec3 GetIKTargetPosition(const string &in IK_label);
    float GetIKWeight(const string &in IK_label);
    BoneTransform GetIKTransform(const string &in IK_label);
    mat4 GetUnmodifiedIKTransform(const string &in IK_label);
    mat4 GetIKTargetTransform(const string &in IK_label);
    void SetMorphTargetWeight(const string &in morph_label, float weight, float weight_weight);
    float GetStatusKeyValue(const string &in status_key_label);
    vec3 GetIKTargetAnimPosition(const string &in IK_label);
    mat4 GetAvgIKChainTransform(const string &in IK_label);
    mat4 GetIKChainTransform(const string &in IK_label, int IK_link);
    vec3 GetIKChainPos(const string &in IK_label, int IK_link);
    void DisableSleep();
    void EnableSleep();
    vec3 GetAvgIKChainPos(const string &in IK_label);
    void SetAnimUpdatePeriod(int steps); // Animation is updated every N engine time steps
    void SheatheItem(int item_id, bool on_right);
    void UnSheatheItem(int item_id, bool on_right);
    void UnStickItem(int item_id);
    void SetPrimaryWeaponID(int item_id);
    vec3 GetModelCenter();
    void RotateBoneToMatchVec(const vec3 &in a, const vec3 &in b, int bone);
    void RotateBonesToMatchVec(const vec3 &in a, const vec3 &in c, int bone, int bone2, float weight);
    void TransformAllFrameMats(const BoneTransform &in transform);
    vec3 GetFrameCenterOfMass();
    vec3 GetTransformedBonePoint(int bone, int point);
    mat4 GetDisplayBoneMatrix(int bone);
    void SetDisplayBoneMatrix(int bone, const mat4 &in transform);
    Skeleton &skeleton();
    AnimationClient &anim_client();
};
const int _awake;
const int _unconscious;
const int _dead;
class MovementObject {
    vec3 position;
    vec3 velocity;
    bool visible;
    int no_grab;
    string char_path;
    bool controlled;
    bool is_player;
    bool static_char;
    int controller_id;
    int update_script_counter;
    int update_script_period;
    bool focused_character;
    RiggedObject@ rigged_object();
    void SetScriptUpdatePeriod(int steps); // Script update() is called every X engine timesteps
    bool HasFunction(const string &in function_definition);
    int QueryIntFunction(string function);
    void Execute(string code);
    bool HasVar(string var_name);
    int GetIntVar(string var_name);
    int GetArrayIntVar(const string &in var_name, int index);
    float GetFloatVar(string var_name);
    bool GetBoolVar(string var_name);
    bool OnSameTeam(MovementObject@ other);
    void ReceiveMessage(const string &in);
    void ReceiveScriptMessage(const string &in);
    void QueueScriptMessage(const string &in);
    int GetID();
    void SetRotationFromFacing(vec3 facing);
    void FixDiscontinuity();
    string GetCurrentControlScript();
    string GetActorScript();
    string GetNPCObjectScript();
    string GetPCObjectScript();
    string GetNPCScript();
    string GetPCScript();
    void ChangeControlScript(const string &path);
    void AddToAttackHistory(const string &in attack_path);
    float CheckAttackHistory(const string &in attack_path);
    void ClearAttackHistory();
    int WasHit(string type, string attack_path, vec3 dir, vec3 pos, int attacker_id, float attack_damage_mult, float attack_knockback_mult);
    void WasBlocked();
    float GetTempHealth();
    void Ragdoll();
    void ApplyForce(vec3 force);
    vec3 GetFacing();
    void UnRagdoll();
    void SetAnimation(string anim_path);
    void SetAnimAndCharAnim(string anim_path, float transition_speed, int8 flags, string char_anim);
    void SwapAnimation(string anim_path);
    void SetAnimation(string anim_path, float transition_speed);
    void SetAnimation(string anim_path, float transition_speed, int8 flags);
    void OverrideCharAnim(const string &in char_anim, const string &in anim_path);
    void SetCharAnimation(string char_anim, float transition_speed, int8 flags);
    void SetCharAnimation(string char_anim, float transition_speed);
    void SetCharAnimation(string char_anim);
    void MaterialEvent(string event, vec3 position);
    void MaterialEvent(string event, vec3 position, float audio_gain);
    void PlaySoundGroupAttached(string path, vec3 position);
    void PlaySoundAttached(string path, vec3 position);
    void PlaySoundGroupVoice(string voice_key, float delay);
    void ForceSoundGroupVoice(string voice_key, float delay);
    void StopVoice();
    vec4 GetAvgRotationVec4();
    int getID();
    void AttachItemToSlot(int item_id, int attachment_type, bool mirrored);
    void DetachItem(int item_id);
    void DetachAllItems();
    void MaterialParticleAtBone(string type, string IK_label);
    void MaterialParticle(const string &in type, const vec3 &in pos, const vec3 &in vel);
    void RecreateRiggedObject(string character_path);
    int GetWaypointTarget();
    void UpdateWeapons();
    void CDrawArms(const BoneTransform &in chest_transform, const BoneTransform &in l_hand_transform, const BoneTransform &in r_hand_transform, int num_frames);
    void CDrawEar(bool right, const BoneTransform &in head_transform, int num_frames);
    void CDrawTail(int num_frames);
    void CFireRibbonUpdate(C_ACCEL @, float delta_time, float curr_game_time);
};
enum EngineState {
    kEngineNoState = 0,
    kEngineLevelState = 1,
    kEngineEditorLevelState = 2,
    kEngineEngineScriptableUIState = 3,
    kEngineCampaignState = 4,
enum SplitScreenMode {
    kModeNone = 0,
    kModeFull = 1,
    kModeSplit = 2,
void LoadLevel(string level_path);
void LoadLevelID(string id);
void SetCampaignID(string id);
string GetCurrLevelAbsPath();
string GetCurrLevel();
string GetCurrLevelRelPath();
string GetLevelName(const string& path);
string GetCurrLevelName();
string GetCurrLevelID();
string GetCurrCampaignID();
string GetCurrentMenuModsourceID();
string GetCurrentLevelModsourceID();
bool EditorModeActive();
void assert(bool val);
void SetSplitScreenMode(SplitScreenMode mode);
int GetNumCharacters();
int GetNumHotspots();
int GetNumItems();
void GetCharactersInSphere(vec3 position, float radius, array<int>@ id_array);
void GetCharacters(array<int>@ id_array);
void GetCharactersInHull(string model_path, mat4, array<int>@ id_array);
void GetObjectsInHull(string model_path, mat4, array<int>@ id_array);
void ResetLevel();
bool DoesItemFitInItem(int item_id, int holster_item_id);
float GetFriction(const vec3 &in position);
void CreateCustomHull(const string &in key, const array<vec3> &vertices);
class Object {
class ItemObject {
    vec3 GetPhysicsPosition();
    vec3 GetLinearVelocity();
    vec3 GetAngularVelocity();
    void SetAngularVelocity(vec3);
    void AddBloodDecal(vec3 position, vec3 direction, float size);
    void CleanBlood();
    mat4 GetPhysicsTransform();
    mat4 GetPhysicsTransformIncludeOffset();
    void SetPhysicsTransform(const mat4 &in);
    void ActivatePhysics();
    bool IsHeld();
    int StuckInWhom();
    int HeldByWhom();
    int GetID();
    void SetLinearVelocity(vec3);
    const string& GetLabel();
    void SetThrown();
    void SetThrownStraight();
    float GetMass();
    bool HasSheatheAttachment();
    int GetNumHands();
    int GetType();
    vec3 GetPoint(string label);
    int GetNumLines();
    vec3 GetLineStart(int line_index);
    vec3 GetLineEnd(int line_index);
    string GetLineMaterial(int line_index);
    const string &GetSoundModifier();
    float GetRangeExtender();
    float GetRangeMultiplier();
    bool CheckThrownSafe();
    void SetSafe();
    ScriptParams@ GetScriptParams();
    int last_held_char_id_;
};
const int _collectable;
const int _misc;
const int _weapon;
const int _item_no_type;
class EnvObject {
    int GetID();
    void CreateLeaf(vec3 target_position, vec3 velocity, int iterations); // Spawn leaf particles from random point on object's surface; more iterations = closer to target_position
    int GetCollisionFace(int index);
    vec3 GetCollisionVertex(int index);
    int GetNumLedgeLines();
    int GetLedgeLine(int index);
};
class Hotspot {
    int GetID();
    string GetTypeString();
    bool HasVar(string& in name);
    bool GetBoolVar(string& in name);
    int GetIntVar(string& in name);
    int GetArrayIntVar(const string &in name, int index);
    float GetFloatVar(string& in name);
    array<int> @GetConnectedObjects();
    bool HasFunction(const string &in function_definition);
    int QueryIntFunction(const string &in function);
    bool QueryBoolFunction(const string &in function);
    float QueryFloatFunction(const string &in function);
    string QueryStringFunction(const string &in function);
    void SetCollisionEnabled(bool);
    bool ConnectTo(Object@);
    bool Disconnect(Object@);
void CFireRibbonUpdate(C_ACCEL @, float delta_time, float curr_game_time, vec3 &in pos);
void CFireRibbonPreDraw(C_ACCEL @, float curr_game_time);
};
enum EntityType {
    _any_type = 0,
    _no_type = 1,
    _camera_type = 2,
    _terrain_type = 11,
    _env_object = 20,
    _movement_object = 21,
    _spawn_point = 23,
    _decal_object = 24,
    _hotspot_object = 26,
    _group = 29,
    _rigged_object = 30,
    _item_object = 32,
    _path_point_object = 33,
    _ambient_sound_object = 34,
    _placeholder_object = 35,
    _light_probe_object = 36,
    _dynamic_light_object = 37,
    _navmesh_hint_object = 38,
    _navmesh_region_object = 39,
    _navmesh_connection_object = 40,
    _reflection_capture_object = 41,
    _light_volume_object = 42,
    _prefab = 43,
};
enum AttachmentType {
    _at_attachment = 2,
    _at_grip = 0,
    _at_sheathe = 1,
    _at_unspecified = 3,
};
enum ConnectionType {
    kCTNone = 0,
    kCTMovementObjects = 1,
    kCTItemObjects = 2,
    kCTEnvObjectsAndGroups = 3,
    kCTPathPoints = 4,
    kCTPlaceholderObjects = 5,
    kCTNavmeshConnections = 6,
    kCTHotspots = 7,
};
    int GetID();
    string GetName();
    void SetName(const string &in);
    bool IsSelected();
    void SetSelected(bool);
    void SetEnabled(bool);
    void SetCollisionEnabled(bool);
    bool GetEnabled();
    void SetTranslation(const vec3 &in);
    vec3 GetTranslation();
    void SetScale(const vec3 &in);
    mat4 GetTransform();
    vec3 GetScale();
    void SetRotation(const quaternion &in);
    void SetTranslationRotationFast(const vec3 &in, const quaternion &in);
    quaternion GetRotation();
    vec4 GetRotationVec4();
    EntityType GetType();
    void SetPlayer(bool);
    bool GetPlayer();
    int GetNumPaletteColors();
    vec3 GetPaletteColor(int which);
    void SetPaletteColor(int which, const vec3 &in color);
    vec3 GetTint();
    void SetTint(const vec3 &in);
    bool ConnectTo(Object@);
    bool Disconnect(Object@);
    void AttachItem(Object@, AttachmentType, bool mirrored);
    void ReceiveScriptMessage(const string &in);
    void QueueScriptMessage(const string &in);
    void UpdateScriptParams();
    void SetCopyable(bool);
    void SetSelectable(bool);
    void SetDeletable(bool);
    void SetScalable(bool);
    void SetTranslatable(bool);
    void SetRotatable(bool);
    void SetEditorLabel(string);
    string GetEditorLabel();
    void SetEditorLabelOffset(vec3);
    vec3 GetEditorLabelOffset();
    void SetEditorLabelScale(float);
    float GetEditorLabelScale();
    ScriptParams@ GetScriptParams();
    string GetLabel();
    vec3 GetBoundingBox();
    bool IsExcludedFromSave();
    bool IsExcludedFromUndo();
    int GetParent();
    array<int>@ GetChildren();
};
Object@ ReadObjectFromID(int);
bool ObjectExists();
array<int> @GetObjectIDs();
array<int> @GetObjectIDsType(int type);
void DeleteObjectID(int);
void QueueDeleteObjectID(int);
int CreateObject(const string &in path, bool exclude_from_save);
int CreateObject(const string &in path);
int DuplicateObject(Object@ obj);
void DeselectAll();
array<int> @GetSelected();
class PathPointObject {
    int NumConnectionIDs();
    int GetConnectionID(int which);
};
    PathPointObject@ opCast();
    Hotspot@ opCast();
MovementObject@ ReadCharacter(int index); // e.g. first character in scene
MovementObject@ ReadCharacterID(int id); // e.g. character with object ID 39
Hotspot@ ReadHotspot(int index);
ItemObject@ ReadItem(int index);
ItemObject@ ReadItemID(int id);
EnvObject@ ReadEnvObjectID(int id);
bool ObjectExists(int id);
bool MovementObjectExists(int id);
bool IsGroupDerived(int id);
void SetPaused(bool paused);
int FindFirstCharacterInGroup(int id);
float GetAnimationEventTime( string &in anim_path, string &in event_label );
MovementObject this_mo;
const int _at_grip;
const int _at_sheathe;
const uint8 _ANM_MIRRORED;
const uint8 _ANM_MOBILE;
const uint8 _ANM_SUPER_MOBILE;
const uint8 _ANM_SWAP;
const uint8 _ANM_FROM_START;
class CharacterScriptGetter { // Can load a character xml and provide access to its data
    bool Load(const string &in); // Load a character xml file (e.g. "Data/Characters/guard.xml")
    string GetObjPath();
    string GetSkeletonPath();
    string GetAnimPath(const string &in anim_label);
    const string& GetTag(const string &in key);
    string GetAttackPath(const string &in attack_label);
    void GetTeamString(string &out team_string);
    float GetHearing();
    const string& GetChannel(int which_channel); // Get type of given color channel (e.g. "fur", "cloth")
    bool GetMorphMetaPoints(const string &in label, vec3 &out start, vec3 &out end);
};
CharacterScriptGetter character_getter;
class ReactionScriptGetter {
    void Load(string path);
    string GetAnimPath(float severity);
    int GetMirrored();
};
ReactionScriptGetter reaction_getter;
